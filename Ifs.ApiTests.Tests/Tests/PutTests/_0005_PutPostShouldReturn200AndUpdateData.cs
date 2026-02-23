using System.Net;
using Ifs.ApiTests.Tests.Models;

namespace Ifs.ApiTests.Tests.Tests;

[TestFixture]
public class _0005_PutPostShouldReturn200AndUpdateData : TestBase
{
    [Test]
    public async Task PutPost_ShouldReturn200_AndUpdateData()
    {
        var id = 1;

        var request = new Post
        {
            Id = id,
            UserId = 1,
            Title = "updated-title",
            Body = "updated-body"
        };

        var (status, _, updated) = await Api.PutAsync<Post, Post>($"/posts/{id}", request);

        Assert.That(status, Is.EqualTo(HttpStatusCode.OK), "Expected 200 OK");
        Assert.That(updated, Is.Not.Null, "Updated post should be deserialized");

        Assert.That(updated!.Id, Is.EqualTo(id), "id should match path");
        Assert.That(updated.UserId, Is.EqualTo(request.UserId), "userId should match submitted data");
        Assert.That(updated.Title, Is.EqualTo(request.Title), "title should match submitted data");
        Assert.That(updated.Body, Is.EqualTo(request.Body), "body should match submitted data");
    }
}