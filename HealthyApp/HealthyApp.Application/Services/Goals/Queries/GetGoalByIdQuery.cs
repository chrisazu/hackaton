using HealthyApp.Application.Models.Response;

using MediatR;

namespace HealthyApp.Application.Services.Goals.Queries
{
    public class GetGoalByIdQuery : IRequest<GoalResponse>
    {
        public GetGoalByIdQuery(int goalId)
        {
            Id = goalId;
        }

        public int Id { get; set; }
    }
}
