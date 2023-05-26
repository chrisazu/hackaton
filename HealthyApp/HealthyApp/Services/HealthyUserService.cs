using System.Web.Http;

using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

namespace HealthyApp.Services
{
    public class HealthyUserService : IHealthyUserService
    {

        private readonly HttpClient _client;
        public HealthyUserService(HttpClient client)
        {
            _client = client;
        }


        public async Task<HealthyUseResponse> Create(HealthyUserRequest request)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("users", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<HealthyUseResponse>();
                }

                throw new HttpResponseException(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
