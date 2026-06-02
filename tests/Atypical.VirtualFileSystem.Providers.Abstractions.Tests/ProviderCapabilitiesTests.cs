namespace Atypical.VirtualFileSystem.Providers.Abstractions.Tests;

public class ProviderCapabilitiesTests
{
    [Fact]
    public void Capabilities_default_to_false_with_token_auth()
    {
        var caps = new ProviderCapabilities();
        caps.SupportsBranches.ShouldBeFalse();
        caps.SupportsPullRequests.ShouldBeFalse();
        caps.AuthKind.ShouldBe(AuthKind.Token);
    }
}
