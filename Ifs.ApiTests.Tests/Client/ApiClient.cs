using System.Net;
using System.Text;
using System.Text.Json;

namespace Ifs.ApiTests.Tests.Client;

public sealed class ApiClient
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiClient(string baseUrl, TimeSpan timeout)
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = timeout
        };

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<(HttpStatusCode Status, string Raw, T? Data)> GetAsync<T>(string path)
    {
        var resp = await _http.GetAsync(path);
        var raw = await resp.Content.ReadAsStringAsync();

        Log("GET", path, null, (int)resp.StatusCode, raw);

        T? data = default;
        if (!string.IsNullOrWhiteSpace(raw))
            data = JsonSerializer.Deserialize<T>(raw, _jsonOptions);

        return (resp.StatusCode, raw, data);
    }

    public async Task<(HttpStatusCode Status, string Raw, TResponse? Data)> PostAsync<TRequest, TResponse>(string path, TRequest body)
    {
        var json = JsonSerializer.Serialize(body, _jsonOptions);
        var resp = await _http.PostAsync(path, new StringContent(json, Encoding.UTF8, "application/json"));
        var raw = await resp.Content.ReadAsStringAsync();

        Log("POST", path, json, (int)resp.StatusCode, raw);

        TResponse? data = default;
        if (!string.IsNullOrWhiteSpace(raw))
            data = JsonSerializer.Deserialize<TResponse>(raw, _jsonOptions);

        return (resp.StatusCode, raw, data);
    }

    public async Task<(HttpStatusCode Status, string Raw, TResponse? Data)> PutAsync<TRequest, TResponse>(string path, TRequest body)
    {
        var json = JsonSerializer.Serialize(body, _jsonOptions);
        var resp = await _http.PutAsync(path, new StringContent(json, Encoding.UTF8, "application/json"));
        var raw = await resp.Content.ReadAsStringAsync();

        Log("PUT", path, json, (int)resp.StatusCode, raw);

        TResponse? data = default;
        if (!string.IsNullOrWhiteSpace(raw))
            data = JsonSerializer.Deserialize<TResponse>(raw, _jsonOptions);

        return (resp.StatusCode, raw, data);
    }

    public async Task<(HttpStatusCode Status, string Raw)> DeleteAsync(string path)
    {
        var resp = await _http.DeleteAsync(path);
        var raw = await resp.Content.ReadAsStringAsync();

        Log("DELETE", path, null, (int)resp.StatusCode, raw);

        return (resp.StatusCode, raw);
    }

    private static void Log(string method, string path, string? requestBody, int status, string responseBody)
    {
        Console.WriteLine($"[{method}] {path}");
        if (!string.IsNullOrWhiteSpace(requestBody))
            Console.WriteLine($"Request: {requestBody}");
        Console.WriteLine($"Status: {status}");
        if (!string.IsNullOrWhiteSpace(responseBody))
            Console.WriteLine($"Response: {responseBody}");
        Console.WriteLine(new string('-', 60));
    }
}
