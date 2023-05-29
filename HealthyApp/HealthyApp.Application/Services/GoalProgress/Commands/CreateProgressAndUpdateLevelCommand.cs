using HealthyApp.Application.Models.Response;
using MediatR;

namespace HealthyApp.Application.Services.GoalProgress.Commands
{
    public class CreateProgressAndUpdateLevelCommand : IRequest<ProgressResponse>
    {
		public int GoalId { get; set; }

		public int Value { get; set; }
    }
}
