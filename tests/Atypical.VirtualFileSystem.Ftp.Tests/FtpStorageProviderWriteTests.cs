namespace Atypical.VirtualFileSystem.Ftp.Tests;

public class FtpStorageProviderWriteTests
{
    private static async Task<FtpStorageProvider> AuthedProviderAsync(FakeFtpConnection fake)
    {
        var provider = new FtpStorageProvider(_ => fake);
        // authenticate (fake connect succeeds)
        await provider.Auth.AuthenticateAsync(new AuthRequest { Host = "h", Username = "u", Password = "p" });
        return provider;
    }

    [Fact]
    public async Task WriteChangesAsync_uploads_adds_and_updates_and_reports_per_file()
    {
        var fake = new FakeFtpConnection();
        var provider = await AuthedProviderAsync(fake);

        var changes = new List<ProviderFileChange>
        {
            new() { RemotePath = "/data/new.txt", Kind = ChangeKind.Add, Content = "x"u8.ToArray() },
            new() { RemotePath = "/data/edit.txt", Kind = ChangeKind.Update, Content = "y"u8.ToArray() },
        };

        var result = await provider.WriteChangesAsync(changes, CommitContext.Empty);

        result.Success.ShouldBeTrue();
        result.FileResults.Count.ShouldBe(2);
        fake.Uploaded.ShouldContain("/data/new.txt");
        fake.Files["/data/edit.txt"].ShouldBe("y"u8.ToArray());
        result.PullRequestUrl.ShouldBeNull();
    }

    [Fact]
    public async Task WriteChangesAsync_deletes_files()
    {
        var fake = new FakeFtpConnection();
        fake.Files["/data/gone.txt"] = "z"u8.ToArray();
        var provider = await AuthedProviderAsync(fake);

        var result = await provider.WriteChangesAsync(
            [new() { RemotePath = "/data/gone.txt", Kind = ChangeKind.Delete }], CommitContext.Empty);

        result.Success.ShouldBeTrue();
        fake.Deleted.ShouldContain("/data/gone.txt");
    }
}
