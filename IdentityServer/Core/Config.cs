using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Core
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("yesterdayApi", "YesterdayApi")
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = configuration.GetSection("IdentityConfig:ClientId").Value,
                    // resource owner password grant client
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret(configuration.GetSection("IdentityConfig:ClientSecret").Value.Sha256())
                    },

                    // allow refresh tokens
                    AllowOfflineAccess = true,

                    // when refreshing the token, the lifetime of the refresh token will be renewed
                    RefreshTokenExpiration = TokenExpiration.Sliding,

                    // makes it so you can reuse the refresh token multiple times(better change it)
                    RefreshTokenUsage = TokenUsage.ReUse,

                    // force the access tokens to refresh in the Profile service
                    UpdateAccessTokenClaimsOnRefresh = true,

                    // scopes that client has access to
                    AllowedScopes =
                    {
                        "yesterdayApi",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email()
            };
        }
    }
}