using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using MediatR;


namespace HealthyApp.Application.Services.GoalProgress.Commands
{
    public class CreateProgressAndUpdateLevelCommandHandler : IRequestHandler<CreateProgressAndUpdateLevelCommand, ProgressResponse>
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IHealthyUserRepository _healthyUserRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IRewardRepository _rewardlRepository;
        private readonly IMapper _mapper;

        public CreateProgressAndUpdateLevelCommandHandler(IGoalRepository goalRepository, IMapper mapper, IHealthyUserRepository healthyUserRepository, ILevelRepository levelRepository, IRewardRepository rewardlRepository)
        {
            _goalRepository = goalRepository;
            _healthyUserRepository = healthyUserRepository;
            _levelRepository = levelRepository;
            _rewardlRepository = rewardlRepository;
            _mapper = mapper;
        }

        public async Task<ProgressResponse> Handle(CreateProgressAndUpdateLevelCommand request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetByIdWithUserProgress(request.GoalId, cancellationToken);

            if (goal == null) { throw new ArgumentNullException("Goal not found"); }

            var user = await _healthyUserRepository.GetByIdWithGoalsLevel(goal.User.Id, cancellationToken);

            if (user == null) { throw new ArgumentNullException("User not found"); }

            Progress progress;

            if (goal is DietGoal)
            {
                progress = _mapper.Map<DietProgress>(request);
            }
            else
            {
                progress = _mapper.Map<ExerciseProgress>(request);
            }

            goal.AddProgress(progress);

            await _goalRepository.Update(goal, cancellationToken);

            if (user.ShouldLevelBeUpdated())
            {
                var idNextLevel = user.Level.Id + 1;

                var nextLevel = await _levelRepository.GetById(idNextLevel, cancellationToken);

                nextLevel.Rewards = user.Level.Rewards;

                user.Level = nextLevel;

                var nextReward = await _rewardlRepository.GetById(nextLevel.Id, cancellationToken);

                user.Level.Rewards.Add(nextReward);

                await _healthyUserRepository.Update(user, cancellationToken);
            }

            return _mapper.Map<ProgressResponse>(progress);
        }
    }
}