namespace LoggingHandler.Infra.FileSystem.Shared;

public interface IFileService
{
    public Task<FilePath> SaveLogFile(string searchIdentifier, string partialPath, string extension, string log);
}
