namespace Atypical.VirtualFileSystem.Providers.Abstractions.Tests;

public class ProviderLoadOptionsTests
{
    [Fact]
    public void Defaults_use_eager_strategy_and_ten_megabyte_max_file_size()
    {
        var options = new ProviderLoadOptions();

        options.Strategy.ShouldBe(ProviderLoadingStrategy.Eager);
        options.MaxFileSizeBytes.ShouldBe(10 * 1024 * 1024);
    }
}
