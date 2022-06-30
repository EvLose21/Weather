using IdentityModel;
using IdentityServer4.Models;

namespace Authorization
{
    public static class Configuration
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes =
                    {
                        "WeatherApi",
                        "WeatherStack"
                    }
                }
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource> {
                new ApiResource("WeatherApi")
            };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource> {
                new IdentityResources.OpenId()
            };
    }
}
