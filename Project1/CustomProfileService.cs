
using System.Security.Claims;

using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

namespace Project1
{
    public class CustomProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims.RemoveAll(c => c.Type == "iss");
            context.IssuedClaims.Add(new Claim("iss", "myiss"));

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
