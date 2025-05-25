namespace LoggingHandler.Infra.Client.MyClientTesting;

public interface IIntegrationApiClientGateway
{
    public Task<string> GenerateQrCode(string uri);
}
