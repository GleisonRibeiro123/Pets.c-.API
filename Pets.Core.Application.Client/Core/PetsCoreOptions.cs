using System;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public class PetsApiOptions
    {
        public Action<HttpClient> HttpClientConfiguration { get; set; }
    }
}