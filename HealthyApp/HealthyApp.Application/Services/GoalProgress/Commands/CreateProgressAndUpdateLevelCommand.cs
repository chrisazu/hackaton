using HealthyApp.Application.Models.Response;
using MediatR;

namespace HealthyApp.Application.Services.GoalProgress.Commands
{
    public class CreateProgressAndUpdateLevelCommand : IRequest<ProgressResponse>
    {
		public required int GoalId { get; set; }

		public TimeSpan Value { get; set; }

        public int Kilograms { get; set; }
    }
}
