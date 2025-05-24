namespace TECNM.Residencias.Services;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

internal sealed class EventLogger : IDisposable, IAsyncDisposable
{
    private static readonly Encoding DefaultEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

    private readonly string _category;
    private StreamWriter? _writer;

    public EventLogger(string category)
    {
        _category = category;
    }

    public string Category
        => _category;

    public void Dispose()
    {
        _writer?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (_writer is not null)
        {
            await _writer.DisposeAsync();
        }
    }

    public void WriteLine(string message)
    {
        StreamWriter writer = GetStreamWriter();
        string payload = $"[{DateTimeOffset.Now:yyyy\\-MM\\-dd HH\\:mm\\:ss}] :: {message}";
        writer.WriteLine(payload);
        writer.Flush();
    }

    public async Task WriteLineAsync(string message)
    {
        StreamWriter writer = GetStreamWriter();
        string payload = $"[{DateTimeOffset.Now:yyyy\\-MM\\-dd HH\\:mm\\:ss}] :: {message}";
        await writer.WriteLineAsync(payload);
        await writer.FlushAsync();
    }

    private StreamWriter GetStreamWriter()
    {
        StreamWriter? writer = _writer;
        if (writer is null)
        {
            var now = DateTimeOffset.Now;
            string directory = Path.Combine(App.LogsDirectory, now.Year.ToString(), now.Month.ToString("00"));
            string filename = Path.Combine(directory, $"{_category}.{now:yyyyMMddHHmmss}.log.txt");

            Directory.CreateDirectory(directory);
            var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            writer = _writer = new StreamWriter(stream, DefaultEncoding, leaveOpen: false);
        }

        return writer;
    }
}
