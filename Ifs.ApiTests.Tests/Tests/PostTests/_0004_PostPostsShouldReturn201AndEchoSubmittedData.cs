using System.Net;
using Ifs.ApiTests.Tests.Models;

namespace Ifs.ApiTests.Tests.Tests;

[TestFixture]
public class _0004_PostPostsShouldReturn201AndEchoSubmittedData : TestBase
{
    [Test]
    public async Task PostPosts_ShouldReturn201_AndEchoSubmittedData()
    {
        var request = new Post
        {
            UserId = 1,
            Title = "qa-title",
            Body = "qa-body"
        };

        var (status, _, created) = await Api.PostAsync<Post, Post>("/posts", request);

        Assert.That(status, Is.EqualTo(HttpStatusCode.Created), "Expected 201 Created");
        Assert.That(created, Is.Not.Null, "Created post should be deserialized");

        Assert.That(created!.UserId, Is.EqualTo(request.UserId), "userId should match submitted data");
        Assert.That(created.Title, Is.EqualTo(request.Title), "title should match submitted data");
        Assert.That(created.Body, Is.EqualTo(request.Body), "body should match submitted data");
        Assert.That(created.Id, Is.GreaterThan(0), "Expected generated id > 0");
    }
}