namespace Ifs.ApiTests.Tests.Config;

public class TestConfiguration
{
    public string BaseUrl { get; init; } = default!;
    public int TimeoutSeconds { get; init; } = 30;
}