using System.Web.Http;

using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

namespace HealthyApp.Services
{
    public class HealthyUserService : IHealthyUserService
    {
        private readonly HttpClient _client;
        private readonly ILogger<HealthyUserService> _logger;

        public HealthyUserService(HttpClient client, ILogger<HealthyUserService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<HealthyUserResponse> Create(HealthyUserRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("users", request);

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

        public async Task<HealthyUserResponse> Get(HealthyUserRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"users/GetUserByAspNetUserId/{request.AspNetUserId}");

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
    }
}
