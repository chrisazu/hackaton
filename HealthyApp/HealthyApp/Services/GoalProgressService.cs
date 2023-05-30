using System.Web.Http;

using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

namespace HealthyApp.Services
{
    public class GoalProgressService : IGoalProgressService
    {
        private readonly BackendApiClient _client;
        private readonly ILogger<GoalService> _logger;

        public GoalProgressService(BackendApiClient client, ILogger<GoalService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<GoalProgressResponse> Create(GoalProgressRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.HttpClient.PostAsJsonAsync($"goal/{request.GoalId}/progress", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GoalProgressResponse>();
                }

                throw new HttpResponseException(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
