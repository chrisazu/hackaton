using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;

namespace HealthyApp.Services.Interfaces
{
    public interface IHealthyUserService
    {
        Task<HealthyUserResponse> Create(HealthyUserRequest request);
        
        Task<HealthyUserResponse> Get(HealthyUserRequest request);
    }
}
