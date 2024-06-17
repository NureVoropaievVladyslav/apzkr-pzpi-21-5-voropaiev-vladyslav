using Application.Abstractions.Factories;

namespace Infrastructure.Factories;

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateHttpClient()
    {
        return new HttpClient() { BaseAddress = new Uri("http://10.0.2.2:8081/api/") };
    }
}