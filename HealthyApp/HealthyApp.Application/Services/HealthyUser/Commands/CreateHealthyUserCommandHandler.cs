using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using MediatR;

namespace HealthyApp.Application.Services.HealthyUser.Commands
{
    public class CreateHealthyUserCommandHandler : IRequestHandler<CreateHealthyUserCommand, HealthyUserResponse>
    {

        private readonly IHealthyUserRepository _healthyUserRepository;
        private readonly IMapper _mapper;

        public CreateHealthyUserCommandHandler(IHealthyUserRepository healthyUserRepository, IMapper mapper)
        {
            _healthyUserRepository = healthyUserRepository;
            _mapper = mapper;
        }

        public async Task<HealthyUserResponse> Handle(CreateHealthyUserCommand request, CancellationToken cancellationToken)
        {

            var healthyUser = _mapper.Map<User>(request);

            await _healthyUserRepository.Create(healthyUser, cancellationToken);


            return _mapper.Map<HealthyUserResponse>(healthyUser);

        }
    }
}
