using IdentityServer4;
using IdentityServer4.Models;

namespace Kiss4Web.IdentityServer
{
    public class AuthenticationConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "webdev.angular",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    //// secret for authentication
                    ClientSecrets =
                    {
                        new Secret("D0015702-143D-4A74-8ED4-04AD5433E55C".Sha256())
                    },

                    //AllowOfflineAccess = true,

                    // scopes that client has access to
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "api"
                    },
                    AllowedCorsOrigins = new List<string>{
                        // ==================================== Dev intergration
                        "http://localhost:4200",
                        // ====================================
                        // Team01_DEV localhost
                        "http://localhost:8001",
                        // Team01_TEST localhost
                        "http://localhost:9001",
                        // ====================================
                        // Team02_DEV localhost
                        "http://localhost:8002",
                        // Team02_TEST localhost
                        "http://localhost:9002",

                    }
                }
            };
        }
    }
}
