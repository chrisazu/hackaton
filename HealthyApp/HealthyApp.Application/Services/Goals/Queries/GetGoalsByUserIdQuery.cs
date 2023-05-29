using HealthyApp.Application.Models.Response;

using MediatR;

namespace HealthyApp.Application.Services.Goals.Queries
{
    public class GetGoalsByUserIdQuery : IRequest<IEnumerable<GoalResponse>>
    {
        public GetGoalsByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
