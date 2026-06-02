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

    [Fact]
    public void Capabilities_default_to_false_with_token_auth()
    {
        var caps = new ProviderCapabilities();
        caps.SupportsBranches.ShouldBeFalse();
        caps.SupportsPullRequests.ShouldBeFalse();
        caps.AuthKind.ShouldBe(AuthKind.Token);
    }
}
