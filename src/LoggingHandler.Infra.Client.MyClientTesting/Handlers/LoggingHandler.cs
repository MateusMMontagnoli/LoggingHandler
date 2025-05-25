using System.Text;
using LoggingHandler.Infra.FileSystem.Shared;

namespace LoggingHandler.Infra.Client.MyClientTesting.Handlers;

public class LoggingHandler : DelegatingHandler
{
    private readonly IFileService _fileService;
    public LoggingHandler(IFileService fileService)
    {
        _fileService = fileService;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var haveSearchIdentifierHeader = request.Headers.TryGetValues("SearchIdentifier", out var searchIdentifier);
        var haveIgnoreContentHeader = request.Headers.TryGetValues("IgnoreContent", out var ignoreContent);

        if (!haveSearchIdentifierHeader)
        {
            throw new Exception("Required 'SearchIdentifier' Header");
        }

        //string? requestLogFilePath = null;
        //string? responseLogFilePath = null;

        if (request.Content is not null && !haveIgnoreContentHeader)
        {
            var type = request.Content.Headers.ContentType?.MediaType;

            var body = await request.Content.ReadAsStringAsync(CancellationToken.None);

            var requestLog = await _fileService.SaveLogFile(searchIdentifier!.FirstOrDefault()!, "request", GetExtensionFromMediaType(type), body);
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.Content is not null)
        {
            var body = await response.Content!.ReadAsStringAsync(cancellationToken);

            var type = response.Content!.Headers.ContentType?.MediaType;

            if (!string.IsNullOrWhiteSpace(body))
            {
                var responseLog = await _fileService.SaveLogFile(searchIdentifier!.FirstOrDefault()!, "response", GetExtensionFromMediaType(type), body);
            }

            response.Content = new StringContent(body, Encoding.UTF8, type ?? "application/json");
        }

        return response;
    }


    private string GetExtensionFromMediaType(string? mediaType)
        => mediaType?.ToLower() switch
        {
            "application/json" => "json",
            "application/xml" => "xml",
            _ => "text"
        };
}
