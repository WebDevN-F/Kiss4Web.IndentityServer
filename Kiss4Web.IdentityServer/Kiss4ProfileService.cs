using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Security.Claims;

namespace Kiss4Web.IdentityServer
{
    public class Kiss4ProfileService : IProfileService
    {
        public Kiss4ProfileService()
        {
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await Task.Run(() => {
                context.IssuedClaims.Add(new Claim("kiss4Claim.name", "admin"));
                context.IssuedClaims.Add(new Claim("kiss4Claim.role", "admin"));
            });
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            await Task.Run(() => {
                context.IsActive = true;
            });
        }

        private string GetLongName(string firstName, string lastName, int userId)
        {
            string longName = "";

            if (!string.IsNullOrEmpty(firstName))
            {
                longName += firstName;
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                longName += ", " + lastName;
            }
            if (userId > 0)
            {
                longName += " (" + userId.ToString() + ")";
            }
            return longName;
        }
    }
}
