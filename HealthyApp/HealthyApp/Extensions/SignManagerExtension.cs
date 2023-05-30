using System.Security.Claims;

using Microsoft.AspNetCore.Identity;

namespace HealthyApp.Extensions
{
    public static class SignManagerExtension
    {
        public static async Task UpdateClaim(this SignInManager<IdentityUser> signInManager, string type, string value)
        {
            var userId = signInManager.Context.User.Claims.FirstOrDefault(c => c.Type == "aspNetUserId")?.Value;

            var loggedUser = signInManager.UserManager.Users.First(u => u.Id == userId);

            var levelClaim = signInManager.Context.User.Claims.FirstOrDefault(c => c.Type == type);

            await signInManager.UserManager.RemoveClaimAsync(loggedUser, levelClaim);

            await signInManager.UserManager.AddClaimAsync(loggedUser, new Claim(type, value));
        }
    }
}
