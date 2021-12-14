using IdentityServer4.Models;
using IdentityServer4.Validation;
using Kiss4Web.Infrastructure.Authentication;

namespace Kiss4Web.IdentityServer
{
    public class Kiss4PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly Scrambler _scrambler;

        public Kiss4PasswordValidator(Scrambler scrambler)
        {
            _scrambler = scrambler;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            await Task.Run(() =>
            {
                // Password = kiSS4web
                var scrambledPasswordToCheck = _scrambler.EncryptString(context.Password);
                if (scrambledPasswordToCheck == "liS5YlBfQ1xlhc3370XYjw==")
                {
                    context.Result = new GrantValidationResult("admin", "custom");
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Username/Password invalid grant");
                }
            });
            
        }
    }
}
