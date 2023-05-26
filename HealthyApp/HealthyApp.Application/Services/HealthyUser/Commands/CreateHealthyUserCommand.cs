using HealthyApp.Application.Models.Response;

using MediatR;

namespace HealthyApp.Application.Services.HealthyUser.Commands
{
	public class CreateHealthyUserCommand : IRequest<HealthyUserResponse>
    {
        public required string AspNetUserId { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }
    }
}
