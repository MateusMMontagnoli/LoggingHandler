using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace LoggingHandler.Infra.FileSystem.Shared;

public class VolumeFileService : IFileService
{
    public string _logPath { get; set; }

    public VolumeFileService(IConfiguration config)
    {
        _logPath = config["LogPath"] ?? "/app/shared-logs";
    }

    public async Task<FilePath> SaveLogFile(string searchIdentifier, string partialPath, string extension, string log)
    {
        var uuid = Guid.NewGuid().ToString();

        var fileName = $"{searchIdentifier}_{uuid}.{extension}";

        var filePath = FilePath.CreateFilePath(uuid, _logPath, partialPath, fileName);

        Directory.CreateDirectory(filePath.GetDirectory());

        using var writer = new StreamWriter(filePath.GetFilePath(), false, new UTF8Encoding(true));

        await writer.WriteAsync(log);

        return filePath;
    }
}
