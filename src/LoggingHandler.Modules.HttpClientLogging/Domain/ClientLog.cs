namespace LoggingHandler.Modules.HttpClientLogging.Domain;

class ClientLog
{
    public Guid Id { get; set; }

    public string SearchIdentifier { get; set; }

    public string Application { get; set; }

    public string Client { get; set; }

    public int? StatusCode { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime? ResponseDate { get; set; }
    
    public string? RequestPath { get; set; }

    public string? ResponsePath { get; set; }

    public ClientLog(
        Guid id,
        string searchIdentifier,
        string application,
        string client,
        DateTime requestDate,
        string? requestPath
    )
    {
        Id = id;
        SearchIdentifier = searchIdentifier;
        Application = application;
        Client = client;
        RequestDate = requestDate;
        RequestPath = requestPath;
    }

    public ClientLog(
        Guid id, 
        string searchIdentifier, 
        string application, 
        string client, 
        int statusCode, 
        DateTime requestDate, 
        DateTime? responseDate, 
        string? requestPath, 
        string? responsePath
    )
    {
        Id = id;
        SearchIdentifier = searchIdentifier;
        Application = application;
        Client = client;
        StatusCode = statusCode;
        RequestDate = requestDate;
        ResponseDate = responseDate;
        RequestPath = requestPath;
        ResponsePath = responsePath;
    }

    public void SetResponseData(int statusCode, DateTime responseDate, string responsePath)
    {
        StatusCode = statusCode;
        ResponseDate = responseDate;
        ResponsePath = responsePath;
    }
}
