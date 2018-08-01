using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace YNAB.Rest
{
    public static class ApiClient
    {
        public static IApiClient Create()
        {
            return Create("https://api.youneedabudget.com/v1");
        }

        public static IApiClient Create(string hostUrl)
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

            return RestService.For<IApiClient>(hostUrl, refitSettings);
        }
    }
}
