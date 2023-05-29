using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using MediatR;

namespace HealthyApp.Application.Services.Goals.Commands
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, GoalResponse>
    {
        private readonly IHealthyUserRepository _healthyUserRepository;
        private readonly IMapper _mapper;

        public CreateGoalCommandHandler(IHealthyUserRepository healthyUserRepository, IMapper mapper)
        {
            _healthyUserRepository = healthyUserRepository;
            _mapper = mapper;
        }

        public async Task<GoalResponse> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            var user = await _healthyUserRepository.GetById(request.UserId, cancellationToken);

            if (user == null) { throw new ArgumentNullException("User not found"); }

            Goal goal;

            if (request.Type == Domain.Enums.GoalType.Diet)
            {
                goal = _mapper.Map<DietGoal>(request);
            }
            else
            {
                goal = _mapper.Map<ExerciseGoal>(request);
            }

            user.Goals.Add(goal);

            await _healthyUserRepository.Update(user, cancellationToken);

            return _mapper.Map<GoalResponse>(goal);
        }
    }
}
