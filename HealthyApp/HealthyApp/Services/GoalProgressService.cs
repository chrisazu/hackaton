using System.Web.Http;

using HealthyApp.Extensions;
using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace HealthyApp.Services
{
    public class GoalProgressService : IGoalProgressService
    {
        private readonly BackendApiClient _client;
        private readonly ILogger<GoalService> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public GoalProgressService(BackendApiClient client, ILogger<GoalService> logger, SignInManager<IdentityUser> signInManager)
        {
            _client = client;
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<GoalProgressResponse> Create(GoalProgressRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.HttpClient.PostAsJsonAsync($"goal/{request.GoalId}/progress", request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<GoalProgressResponse>();

                    if (result.NewLevel != null)
                    {
                        await _signInManager.UpdateClaim("level", result.NewLevel.Name);
                    }

                    return result;
                }

                throw new HttpResponseException(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

            //async Task UpdateClaim(GoalProgressResponse? result)
            //{
            //    var loggedUser = _signInManager.UserManager.Users.First();

            //    var levelClaim = _signInManager.Context.User.Claims.FirstOrDefault(c => c.Type == "level");

            //    await _signInManager.UserManager.RemoveClaimAsync(loggedUser, levelClaim);

            //    await _signInManager.UserManager.AddClaimAsync(loggedUser, new Claim("level", result.NewLevel.Name));
            //}
        }
    }
}
