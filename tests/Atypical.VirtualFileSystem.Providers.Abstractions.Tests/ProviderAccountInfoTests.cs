namespace Atypical.VirtualFileSystem.Providers.Abstractions.Tests;

public class ProviderAccountInfoTests
{
    [Fact]
    public void Anonymous_has_anonymous_display_name_and_null_quota_and_rate_fields()
    {
        var account = ProviderAccountInfo.Anonymous;

        account.DisplayName.ShouldBe("Anonymous");
        account.QuotaUsedBytes.ShouldBeNull();
        account.QuotaTotalBytes.ShouldBeNull();
        account.RateLimitRemaining.ShouldBeNull();
        account.RateLimitTotal.ShouldBeNull();
        account.RateLimitReset.ShouldBeNull();
    }
}
