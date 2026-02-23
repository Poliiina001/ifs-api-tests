using System.Net;
using Ifs.ApiTests.Tests.Models;

namespace Ifs.ApiTests.Tests.Tests;

[TestFixture]
public class _0002_GetPostByIdShouldReturn200AndCorrectPost : TestBase
{
    [Test]
    public async Task GetPostById_ShouldReturn200_AndCorrectPost()
    {
        var id = 1;
        var (status, _, post) = await Api.GetAsync<Post>($"/posts/{id}");

        Assert.That(status, Is.EqualTo(HttpStatusCode.OK), "Expected 200 OK");
        Assert.That(post, Is.Not.Null, "Response should be deserialized to Post");
        Assert.That(post!.Id, Is.EqualTo(id), "Returned post id should match requested id");
        Assert.That(post.Title, Is.Not.Empty, "Post.title should not be empty");
        Assert.That(post.Body, Is.Not.Empty, "Post.body should not be empty");
    }
}