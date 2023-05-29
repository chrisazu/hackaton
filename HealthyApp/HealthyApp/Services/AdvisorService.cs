using System.Web.Http;

using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

namespace HealthyApp.Services
{
    public class AdvisorService : IAdvisorService
    {

        private readonly HttpClient _client;
        private readonly ILogger<GoalService> _logger;
        IHttpContextAccessor _httpContextAccessor;

        public AdvisorService(HttpClient client, ILogger<GoalService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AskForRecomendations(AdviseRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"user/{_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId").Value}/goals/{request.SelectedGoal}");

                if (response.IsSuccessStatusCode)
                {
                    GoalResponse goalResponse = await response.Content.ReadFromJsonAsync<GoalResponse>();

                    string message = CreateMessage(goalResponse);

                }

                throw new HttpResponseException(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        private string CreateMessage(GoalResponse? goal)
        {
            string text = $"Mi objetivo es {goal.Type} por {goal.Duration}, {goal.TimesPerFrequency} veces por {goal.Frequency}";

            //if (goal.Progress.Any())
            //{
            //    text += goal.Progress.Sum(s=>s.Value)
            //}
            return text;
        }
    }
}
