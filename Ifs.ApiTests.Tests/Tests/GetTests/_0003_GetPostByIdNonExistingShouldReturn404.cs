using System.Net;
using Ifs.ApiTests.Tests.Models;

namespace Ifs.ApiTests.Tests.Tests;

[TestFixture]
public class _0003_GetPostByIdNonExistingShouldReturn404 : TestBase
{
    [Test]
    public async Task GetPostById_NonExisting_ShouldReturn404()
    {
        var nonExistingId = 99999;
        var (status, raw, _) = await Api.GetAsync<object>($"/posts/{nonExistingId}");

        Assert.That(status, Is.EqualTo(HttpStatusCode.NotFound),
            $"Expected 404 Not Found for non-existing post. Raw response: {raw}");
    }
}