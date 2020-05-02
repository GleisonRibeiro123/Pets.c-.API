using System.Net.Http;
using System.Threading.Tasks;

namespace Pets.Core.Application.Client
{
    internal static class IHttpClientFactoryExtension
    {
        public static async Task<TResult> PostAsync<TResult>(this IHttpClientFactory httpFactory, string url, object body)
        {
            var httpClient = httpFactory.CreateClient(Constants.HttpClientName);
            var response = await httpClient.PostAsJsonAsync(url, body);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TResult>();
        }

        public static async Task PostAsync(this IHttpClientFactory httpFactory, string url, object body)
        {
            var httpClient = httpFactory.CreateClient(Constants.HttpClientName);
            var response = await httpClient.PostAsJsonAsync(url, body);
            response.EnsureSuccessStatusCode();

            return;
        }

    }
}
