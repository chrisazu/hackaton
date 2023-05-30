using System.Web.Http;

using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

namespace HealthyApp.Services
{
    public class GoalService : IGoalService
    {
        private readonly BackendApiClient _client;
        private readonly ILogger<GoalService> _logger;

        public GoalService(BackendApiClient client, ILogger<GoalService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<GoalResponse[]> GetByUserId(GoalRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.HttpClient.GetAsync($"user/{request.UserId}/goals");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GoalResponse[]>();
                }

                throw new HttpResponseException(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<GoalResponse> GetById(GoalRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.HttpClient.GetAsync($"user/{request.UserId}/goals/{request.Id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GoalResponse>();
                }

                throw new HttpResponseException(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<HealthyUserResponse> Create(HealthyUserRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.HttpClient.PostAsJsonAsync("users", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<HealthyUserResponse>();
                }

                throw new HttpResponseException(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<GoalResponse> Create(AddGoalRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.HttpClient.PostAsJsonAsync($"user/{request.UserId}/goals", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GoalResponse>();
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
