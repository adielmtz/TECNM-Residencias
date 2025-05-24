namespace TECNM.Residencias.Services.DTO;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

internal sealed class GitHubRelease
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public long Id { get; set; }

    [JsonPropertyName("url")]
    [JsonRequired]
    public Uri Url { get; set; } = null!;

    [JsonPropertyName("tag_name")]
    [JsonRequired]
    public string TagName { get; set; } = null!;

    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; } = null!;

    [JsonPropertyName("draft")]
    [JsonRequired]
    public bool Draft { get; set; }

    [JsonPropertyName("prerelease")]
    [JsonRequired]
    public bool Prerelease { get; set; }

    [JsonPropertyName("created_at")]
    [JsonRequired]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("published_at")]
    [JsonRequired]
    public DateTimeOffset PublishedAt { get; set; }

    [JsonPropertyName("assets")]
    [JsonRequired]
    public IList<GitHubAsset> Assets { get; set; } = [];
}
