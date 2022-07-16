using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using GoRest.Api.Client.Client.Interfaces;
using GoRest.Api.Client.Client.Realization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestEase;

namespace GoRest.Api.Client.Client
{
    public class GoRestClient
    {
        private readonly CookieContainer _cookieContainer = new CookieContainer();

        private GoRestClient() { }

        /// <summary>
        /// Created NgPagesApiClient with 'Auth' and 'Referer' headers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T For<T>() where T : ISupportBearerAuth
        {
            var client = new GoRestClient(){};
            
            var httpClient = client.CreateHttpClient(new Dictionary<string, string>());
            var restClient = client.CreateRestClient<T>(httpClient)
                .AddValidAuthHeader("1471c9cece25b11a29b5cd36f0a956dad30e0f1823df6175a11840878e2c59e8");
            
            return restClient;
        }

        private HttpClient CreateHttpClient(Dictionary<string, string> headers)
        {
            var handler = new HttpClientHandler {UseCookies = true, CookieContainer = _cookieContainer};
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://gorest.co.in/public-api/")
            };
            foreach (var header in headers) httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            return httpClient;
        }

        private T CreateRestClient<T>(HttpClient httpClient)
        {
            var restClient = new RestClient(httpClient)
            {
                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver(){NamingStrategy = new LowerCaseNamingStrategy()},
                    Converters = {new StringEnumConverter()}
                }
            };

            var client = restClient.For<T>();
            return client;
        }
    }
}