using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;

namespace HealthyApp.Services.Interfaces
{
    public interface IGoalService
    {
        Task<GoalResponse[]> GetByUserId(GoalRequest request);

        Task<GoalResponse> GetById(GoalRequest request);
    }
}
