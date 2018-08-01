using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Net.Http;

namespace YNAB.Rest
{
    public static class ApiClient
    {
        /// <summary>
        /// Creates an client for calling the YNAB REST API.
        /// </summary>
        /// <param name="accessToken">The API access token.</param>
        /// <returns>An API client.</returns>
        public static IApiClient Create(string accessToken)
        {
            return Create(accessToken, "https://api.youneedabudget.com/v1");
        }

        /// <summary>
        /// Creates an client for calling the YNAB REST API.
        /// </summary>
        /// <param name="accessToken">The API access token.</param>
        /// <param name="hostUrl">The base address of the YNAB REST API.</param>
        /// <returns>An API client.</returns>
        public static IApiClient Create(string accessToken, string hostUrl)
        {
            var refitSettings = new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                }
            };

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(hostUrl);
            httpClient.DefaultRequestHeaders.Add("Authorization", "BEARER " + accessToken);

            return RestService.For<IApiClient>(httpClient, refitSettings);
        }
    }
}
