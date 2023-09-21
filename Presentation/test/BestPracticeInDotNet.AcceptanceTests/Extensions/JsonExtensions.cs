using System.Text.Json;

namespace BestPracticeInDotNet.AcceptanceTests.Extensions;

public static class JsonExtensions
{
    public static string ParseJson(this string json)
    {
        using var jDoc = JsonDocument.Parse(json);
        return JsonSerializer.Serialize(jDoc, new JsonSerializerOptions { WriteIndented = true });
    }
}