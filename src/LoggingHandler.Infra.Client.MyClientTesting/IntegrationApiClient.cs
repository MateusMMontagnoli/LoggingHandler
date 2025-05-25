
namespace LoggingHandler.Infra.Client.MyClientTesting;

public class IntegrationApiClient : IIntegrationApiClientGateway
{
    public IntegrationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public HttpClient _httpClient { get; set; }

    public async Task<string> GenerateQrCode(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/random/qrcode?uri={uri}");

        request.Headers.Add("SearchIdentifier", "teste-search");

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        // TODO: Create DTOs for communication between services
        return await response.Content.ReadAsStringAsync();
    }
}
