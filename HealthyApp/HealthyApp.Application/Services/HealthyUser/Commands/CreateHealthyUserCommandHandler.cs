using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using MediatR;

namespace HealthyApp.Application.Services.HealthyUser.Commands
{
    public class CreateHealthyUserCommandHandler : IRequestHandler<CreateHealthyUserCommand, HealthyUserResponse>
    {
        private const int FIRST_LEVEL = 1;
        private readonly IHealthyUserRepository _healthyUserRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public CreateHealthyUserCommandHandler(IHealthyUserRepository healthyUserRepository, IMapper mapper, ILevelRepository levelRepository)
        {
            _healthyUserRepository = healthyUserRepository;
            _mapper = mapper;
            _levelRepository = levelRepository;
        }

        public async Task<HealthyUserResponse> Handle(CreateHealthyUserCommand request, CancellationToken cancellationToken)
        {

            var healthyUser = _mapper.Map<User>(request);

            healthyUser.Level = await _levelRepository.GetById(FIRST_LEVEL, cancellationToken);

            await _healthyUserRepository.Create(healthyUser, cancellationToken);


            return _mapper.Map<HealthyUserResponse>(healthyUser);

        }
    }
}
