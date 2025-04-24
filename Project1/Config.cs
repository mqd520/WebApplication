using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Project1;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope(name:"api", displayName:"MyApi")
            };

    public static IEnumerable<Client> Clients
    {
        get
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    Claims = [
                        new ClientClaim("myclaim","myclaim")
                    ],
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api", IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile }
                },
            };
        }
    }
}