namespace Application.Abstractions.Factories;

public interface IHttpClientFactory
{
    HttpClient CreateHttpClient();
}