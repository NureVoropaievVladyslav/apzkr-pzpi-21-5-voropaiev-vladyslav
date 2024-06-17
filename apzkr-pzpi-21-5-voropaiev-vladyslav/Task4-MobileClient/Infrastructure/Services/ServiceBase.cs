using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using Application.Abstractions.Factories;
using Infrastructure.Configurations.Auth;

namespace Infrastructure.Services;

public class ServiceBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AuthConfiguration _authConfiguration;

    public ServiceBase(IHttpClientFactory httpClientFactory, AuthConfiguration authConfiguration)
    {
        _httpClientFactory = httpClientFactory;
        _authConfiguration = authConfiguration;
    }

    public async Task SendRequestAsync<TRequest>(HttpMethod httpMethod, string apiEndpoint, TRequest requestBody,
        CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateHttpClient();

        var request = new HttpRequestMessage()
        {
            Content = JsonContent.Create(requestBody),
            Method = httpMethod,
            RequestUri = new Uri(apiEndpoint, UriKind.Relative)
        };
        
        if (_authConfiguration.AccessToken is not null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authConfiguration.AccessToken);
        }
        
        await httpClient.SendAsync(request, cancellationToken);
    }
    
    public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod httpMethod, string apiEndpoint, TRequest requestBody,
        CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateHttpClient();

        var request = new HttpRequestMessage()
        {
            Content = JsonContent.Create(requestBody),
            Method = httpMethod,
            RequestUri = new Uri(apiEndpoint, UriKind.Relative)
        };
        
        if (_authConfiguration.AccessToken is not null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authConfiguration.AccessToken);
        }
        
        var response = await httpClient.SendAsync(request, cancellationToken);
        return await response.Content.ReadFromJsonAsync<TResponse>() ?? default;
    }
    
    public async Task<TResponse> SendRequestAsync<TResponse>(HttpMethod httpMethod, string apiEndpoint, CancellationToken cancellationToken,
        IDictionary<string, string>? queryParams = null)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        // foreach (var param in queryParams ?? new Dictionary<string, string>())
        // {
        //     queryString[param.Key] = param.Value;
        // }
        
        var httpClient = _httpClientFactory.CreateHttpClient();

        var request = new HttpRequestMessage()
        {
            Method = httpMethod,
            RequestUri = new Uri($"{apiEndpoint}{queryString}", UriKind.Relative),
        };
        
        if (_authConfiguration.AccessToken is not null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authConfiguration.AccessToken);
        }
        
        var response = await httpClient.SendAsync(request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _authConfiguration.AccessToken = null;
            return default;
        }
        
        return await response.Content.ReadFromJsonAsync<TResponse>() ?? default;
    }
}