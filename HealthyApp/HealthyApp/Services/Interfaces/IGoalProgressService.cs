using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;

namespace HealthyApp.Services.Interfaces
{
    public interface IGoalProgressService
    {
        Task<GoalProgressResponse> Create(GoalProgressRequest request);
    }
}
