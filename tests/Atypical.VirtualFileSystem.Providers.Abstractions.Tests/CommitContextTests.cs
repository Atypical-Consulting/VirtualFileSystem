namespace Atypical.VirtualFileSystem.Providers.Abstractions.Tests;

public class CommitContextTests
{
    [Fact]
    public void Empty_has_no_message_branch_or_draft()
    {
        var ctx = CommitContext.Empty;
        ctx.Message.ShouldBeNull();
        ctx.Branch.ShouldBeNull();
        ctx.Draft.ShouldBeFalse();
    }
}
