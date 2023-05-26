using HealthyApp.Application.Models.Response;
using MediatR;

namespace HealthyApp.Application.Services.GoalProgress.Commands
{
    public class CreateProgressAndUpdateLevelCommand : IRequest<ProgressResponse>
    {
		public required int GoalId { get; set; }

		public required TimeSpan Value { get; set; }
    }
}
