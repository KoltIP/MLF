using Duende.IdentityServer.Models;
using PetProject.Shared.Common.Security;

namespace PetProject.Identity.Configuration.IS4
{
    public static class AppApiScopes
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope(AppScopes.PetRead, "Access to API - Read data"),
            new ApiScope(AppScopes.PetWrite, "Access to API - Write data")
            };
    }
}
