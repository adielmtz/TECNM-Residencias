namespace TECNM.Residencias.Services.DTO;

using System;
using System.Text.Json.Serialization;

internal sealed class GitHubAsset
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public long Id { get; set; }

    [JsonPropertyName("url")]
    [JsonRequired]
    public Uri Url { get; set; } = null!;

    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; } = null!;

    [JsonPropertyName("size")]
    [JsonRequired]
    public long Size { get; set; }

    [JsonPropertyName("created_at")]
    [JsonRequired]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonRequired]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonPropertyName("browser_download_url")]
    [JsonRequired]
    public Uri BrowserDownloadUrl { get; set; } = null!;
}
