using IdentityModel.Client;

// using Infrastructure.Configuration;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

// using Newtonsoft.Json;
namespace MVC.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<HttpClientService> _logger;

    public HttpClientService(
        IHttpClientFactory clientFactory,
        IHttpContextAccessor httpContextAccessor,
        ILogger<HttpClientService> logger)
    {
        _clientFactory = clientFactory;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content)
    {
        var client = _clientFactory.CreateClient();

        var token = await _httpContextAccessor.HttpContext?.GetTokenAsync("access_token") !;
        _logger.LogInformation($"token is:{token}");

        if (!string.IsNullOrEmpty(token))
        {
            client.SetBearerToken(token);
        }

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response!;
        }

        return default(TResponse) !;
    }
}
