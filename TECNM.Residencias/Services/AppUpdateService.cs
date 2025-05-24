namespace TECNM.Residencias.Services;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Services.DTO;

internal static class AppUpdateService
{
    private const string API_ENDPOINT = "https://api.github.com/repos/adielmtz/TECNM-Residencias/releases";

    public static async Task<bool> CheckForUpdatesAsync()
    {
        try
        {
            AppSettings.Default.LastAppUpdateCheckDate = DateTimeOffset.Now;
            AppSettings.Default.Save();

            GitHubRelease? release = await GetReleaseAsync();

            if (release is null)
            {
                return false;
            }

            GitHubAsset asset = release.Assets.Where(it => it.Name.EndsWith(".exe")).First();
            string filename = await DownloadInstallerAsync(asset.BrowserDownloadUrl, asset.Name);

            DialogResult result = MessageBox.Show(
                """
                Se encontró una actualización del programa.
                ¿Desea descargar e instalar la actualización?
                """,
                "Actualización disponible",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return true;
            }

            var info = new ProcessStartInfo();
            info.FileName = filename;
            info.Arguments = "--wait";

            RecoveryService.KillOtherProcesses();
            Process.Start(info);
            Environment.Exit(0);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static async Task<GitHubRelease?> GetReleaseAsync()
    {
        IList<GitHubRelease> releases = await FetchReleasesAsync();

        foreach (GitHubRelease release in releases)
        {
            string tag = release.TagName;
            if (tag.StartsWith('v'))
            {
                tag = tag.Substring(1);
            }

            Version? version;
            if (Version.TryParse(tag, out version))
            {
                if (version > App.Version)
                {
                    return release;
                }
            }
        }

        return null;
    }

    private static async Task<IList<GitHubRelease>> FetchReleasesAsync()
    {
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, API_ENDPOINT);

        client.Timeout = TimeSpan.FromSeconds(10);
        request.Version = HttpVersion.Version20;
        request.Headers.Add("Accept", "application/vnd.github+json");
        request.Headers.Add("User-Agent", "TECNM.Residencias");

        using HttpResponseMessage response = await client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        List<GitHubRelease>? list = JsonSerializer.Deserialize<List<GitHubRelease>>(content);

        if (list is null)
        {
            return [];
        }

        return list;
    }

    private static async Task<string> DownloadInstallerAsync(Uri url, string name)
    {
        using var handler = new HttpClientHandler();
        handler.AllowAutoRedirect = true;
        handler.MaxAutomaticRedirections = 1;

        using var client = new HttpClient(handler);
        using var request = new HttpRequestMessage(HttpMethod.Get, url);

        client.Timeout = TimeSpan.FromSeconds(30);
        request.Version = HttpVersion.Version20;
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "TECNM.Residencias");

        using HttpResponseMessage response = await client.SendAsync(request);
        await using Stream stream = await response.Content.ReadAsStreamAsync();

        string filename = Path.Combine(Path.GetTempPath(), name);
        await using var output = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        await stream.CopyToAsync(output);

        return filename;
    }
}
