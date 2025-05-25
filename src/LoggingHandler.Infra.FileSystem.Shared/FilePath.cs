namespace LoggingHandler.Infra.FileSystem.Shared;

public class FilePath
{
    public string Identifier { get; set; }

    public string BasePath { get; set; }

    public DatePath DatePath { get; set; }

    public string PartialPath { get; set; }

    public string FileName { get; set; }

    private FilePath(
        string identifier, 
        string basePath,
        DatePath datePath, 
        string partialPath, 
        string fileName
    )
    {
        Identifier = identifier;
        BasePath = basePath;
        DatePath = datePath;
        PartialPath = partialPath;
        FileName = fileName;
    }

    public static FilePath CreateFilePath(string uuid, string basePath, string partialPath, string filename)
        => new(
            uuid,
            basePath,
            DatePath.CreateDatePath(),
            partialPath,
            filename
        );

    public string GetFilePath()
    {
        return Path.Combine(BasePath, PartialPath, DatePath.FilePath, Identifier, FileName);
    }

    public string GetDirectory()
    {
        return Path.Combine(BasePath, PartialPath, DatePath.FilePath, Identifier);
    }

}
