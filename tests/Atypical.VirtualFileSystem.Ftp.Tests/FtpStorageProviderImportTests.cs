namespace Atypical.VirtualFileSystem.Ftp.Tests;

public class FtpStorageProviderImportTests
{
    private static FakeFtpConnection BuildTree()
    {
        var fake = new FakeFtpConnection();
        fake.Directories.Add("/data");
        fake.Directories.Add("/data/sub");
        fake.Files["/data/readme.txt"] = "hello"u8.ToArray();
        fake.Files["/data/sub/a.txt"] = "A"u8.ToArray();
        fake.Files["/data/big.bin"] = new byte[20]; // for size-filter test
        return fake;
    }

    private static async Task<FtpStorageProvider> AuthedProviderAsync(FakeFtpConnection fake)
    {
        var provider = new FtpStorageProvider(_ => fake);
        await provider.Auth.AuthenticateAsync(new AuthRequest { Host = "h", Username = "u", Password = "p" });
        return provider;
    }

    [Fact]
    public async Task ImportAsync_loads_files_recursively_into_the_vfs()
    {
        var fake = BuildTree();
        var provider = await AuthedProviderAsync(fake);
        var vfs = new VFS();

        // No size cap so all three files (including the 20-byte big.bin) load.
        var result = await provider.ImportAsync(vfs, new ProviderLoadOptions { RemoteRoot = "/data", MaxFileSizeBytes = long.MaxValue });

        result.FilesLoaded.ShouldBe(3);
        vfs.Index.ContainsKey(new VFSFilePath("data/readme.txt")).ShouldBeTrue();
        vfs.Index.ContainsKey(new VFSFilePath("data/sub/a.txt")).ShouldBeTrue();
    }

    [Fact]
    public async Task ImportAsync_skips_files_over_the_max_size()
    {
        var fake = BuildTree();
        var provider = await AuthedProviderAsync(fake);
        var vfs = new VFS();

        var result = await provider.ImportAsync(vfs, new ProviderLoadOptions { RemoteRoot = "/data", MaxFileSizeBytes = 10 });

        result.Skipped.ShouldContain(s => s.RemotePath == "/data/big.bin" && s.Reason == ProviderSkipReason.TooLarge);
        vfs.Index.ContainsKey(new VFSFilePath("data/big.bin")).ShouldBeFalse();
    }

    [Fact]
    public async Task ImportAsync_materializes_empty_directories_in_the_vfs()
    {
        var fake = new FakeFtpConnection();
        fake.Directories.Add("/data");
        fake.Directories.Add("/data/empty"); // empty subdirectory: no files inside
        var provider = await AuthedProviderAsync(fake);
        var vfs = new VFS();

        var result = await provider.ImportAsync(vfs, new ProviderLoadOptions { RemoteRoot = "/data" });

        result.FilesLoaded.ShouldBe(0);
        vfs.Index.ContainsKey(new VFSDirectoryPath("data/empty")).ShouldBeTrue();
    }
}
