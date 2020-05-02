using Microsoft.Extensions.DependencyInjection.Extensions;
using Pets.Core.Application.Client;
using Pets.Core.Application.Client.Client;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEzamApi(this IServiceCollection services, string uri, Action<PetsApiOptions> setupOptions = null)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            PetsApiOptions options = new PetsApiOptions();

            setupOptions?.Invoke(options);


            services.AddHttpClient(Constants.HttpClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(uri);
                options.HttpClientConfiguration?.Invoke(httpClient);
            });

            AddServices(services);

            return services;
        }

        private static void AddServices(IServiceCollection services)
        {

            services.TryAddSingleton<PetsCoreClient>();
        }
    }
}