namespace Atypical.VirtualFileSystem.Providers.Abstractions.Tests;

public class ProviderWriteResultTests
{
    [Fact]
    public void Result_with_one_failed_file_result_round_trips()
    {
        var result = new ProviderWriteResult
        {
            Success = false,
            FileResults =
            [
                new ProviderFileWriteResult("/data/file.txt", false, "boom")
            ],
            Message = "write failed"
        };

        result.Success.ShouldBeFalse();
        result.PullRequestUrl.ShouldBeNull();
        result.Message.ShouldBe("write failed");
        result.FileResults.Count.ShouldBe(1);
        result.FileResults[0].RemotePath.ShouldBe("/data/file.txt");
        result.FileResults[0].Success.ShouldBeFalse();
        result.FileResults[0].Message.ShouldBe("boom");
    }
}
