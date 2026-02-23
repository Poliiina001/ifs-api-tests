using System.Text.Json.Serialization;

namespace Ifs.ApiTests.Tests.Models;

public sealed class Post
{
    [JsonPropertyName("userId")]
    public int UserId { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("body")]
    public required string Body { get; init; }
}
