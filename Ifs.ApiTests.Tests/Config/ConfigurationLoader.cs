using Microsoft.Extensions.Configuration;

namespace Ifs.ApiTests.Tests.Config;

public static class ConfigurationLoader
{
    public static TestConfiguration Load()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        var baseUrl = config["Api:BaseUrl"];
        if (string.IsNullOrWhiteSpace(baseUrl))
            throw new InvalidOperationException("Api:BaseUrl is missing in appsettings.json");

        var timeoutSeconds = int.TryParse(config["Api:TimeoutSeconds"], out var t) ? t : 30;

        return new TestConfiguration
        {
            BaseUrl = baseUrl.TrimEnd('/'),
            TimeoutSeconds = timeoutSeconds
        };
    }
}
