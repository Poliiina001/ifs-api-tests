using Ifs.ApiTests.Tests.Client;
using Ifs.ApiTests.Tests.Config;

namespace Ifs.ApiTests.Tests.Tests;

public abstract class TestBase
{
    protected ApiClient Api = default!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var cfg = ConfigurationLoader.Load();
        Api = new ApiClient(cfg.BaseUrl, TimeSpan.FromSeconds(cfg.TimeoutSeconds));
    }
}