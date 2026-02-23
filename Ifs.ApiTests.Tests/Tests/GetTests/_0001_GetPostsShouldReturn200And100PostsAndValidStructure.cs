using System.Net;
using System.Linq;
using NUnit.Framework;
using Ifs.ApiTests.Tests.Models;

namespace Ifs.ApiTests.Tests.Tests;

[TestFixture]
public class _0001_GetPostsShouldReturn200And100PostsAndValidStructure : TestBase
{
    [Test]
    public async Task GetPosts_ShouldReturn200_And100Posts_AndValidStructure()
    {
        var (status, _, data) = await Api.GetAsync<List<Post>>("/posts");

        Assert.That(status, Is.EqualTo(HttpStatusCode.OK), "Expected 200 OK");
        Assert.That(data, Is.Not.Null, "Response should be deserialized to List<Post>");
        Assert.That(data!.Count, Is.EqualTo(100), "Expected exactly 100 posts");

        var first = data.First();
        Assert.That(first.Id, Is.GreaterThan(0), "Post.id should be > 0");
        Assert.That(first.UserId, Is.GreaterThan(0), "Post.userId should be > 0");
        Assert.That(first.Title, Is.Not.Empty, "Post.title should not be empty");
        Assert.That(first.Body, Is.Not.Empty, "Post.body should not be empty");
    }
}