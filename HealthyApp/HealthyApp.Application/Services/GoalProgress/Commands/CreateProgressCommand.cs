using HealthyApp.Application.Models.Response;
using MediatR;

namespace HealthyApp.Application.Services.GoalProgress.Commands
{
    public class CreateProgressCommand : IRequest<ProgressResponse>
    {
        public required TimeSpan Value { get; set; }
    }
}
