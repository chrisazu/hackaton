using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;

namespace HealthyApp.Services.Interfaces
{
    public interface IHealthyUserService
    {
        Task<HealthyUseResponse> Create(HealthyUserRequest request);
    }
}
