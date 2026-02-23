using System.Net;

namespace Ifs.ApiTests.Tests.Tests;

[TestFixture]
public sealed class _0006_DeletePostShouldReturn200 : TestBase
{
    [Test]
    public async Task DeletePost_ShouldReturn200()
    {
        var id = 1;
        var (status, _) = await Api.DeleteAsync($"/posts/{id}");

        Assert.That(status, Is.EqualTo(HttpStatusCode.OK), "Expected 200 OK on delete");
    }
}