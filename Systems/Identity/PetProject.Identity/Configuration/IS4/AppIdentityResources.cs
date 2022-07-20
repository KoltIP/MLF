

using Duende.IdentityServer.Models;

namespace PetProject.Identity.Configuration.IS4
{
    public static class AppIdentityResources
    {
        public static IEnumerable<IdentityResource> Resources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }
}
