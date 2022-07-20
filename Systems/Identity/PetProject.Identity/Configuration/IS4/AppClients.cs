using Duende.IdentityServer.Models;
using IdentityModel;
using PetProject.Shared.Common.Security;
using static IdentityModel.OidcConstants;

namespace PetProject.Identity.Configuration.IS4
{
    public static class AppClients
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            new Client
            {
                ClientId = "swagger",
                ClientSecrets =
                {
                    new Secret("secret".ToSha256())
                },

                AllowedGrantTypes = Duende.IdentityServer.Models.GrantTypes.ClientCredentials,

                AccessTokenLifetime = 3600, // 1 hour

                AllowedScopes = {
                    AppScopes.PetRead,
                    AppScopes.PetWrite
                }
            }
            ,
            new Client
            {
                ClientId = "frontend",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                AllowedGrantTypes = Duende.IdentityServer.Models.GrantTypes.ResourceOwnerPassword,

                AllowOfflineAccess = true,
                AccessTokenType = AccessTokenType.Jwt,

                AccessTokenLifetime = 3600, // 1 hour

                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                RefreshTokenExpiration = TokenExpiration.Sliding,
                AbsoluteRefreshTokenLifetime = 2592000, // 30 days
                SlidingRefreshTokenLifetime = 1296000, // 15 days

                AllowedScopes = {
                    AppScopes.PetRead,
                    AppScopes.PetWrite
                }
            }
            };
    }
}
