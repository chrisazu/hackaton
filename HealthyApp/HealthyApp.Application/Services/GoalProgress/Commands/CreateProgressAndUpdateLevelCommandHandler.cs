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
        private readonly IMapper _mapper;

        public CreateProgressAndUpdateLevelCommandHandler(IGoalRepository goalRepository, IMapper mapper, IHealthyUserRepository healthyUserRepository, ILevelRepository levelRepository)
        {
            _goalRepository = goalRepository;
            _healthyUserRepository = healthyUserRepository;
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public async Task<ProgressResponse> Handle(CreateProgressAndUpdateLevelCommand request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetByIdWithUserProgress(request.GoalId, cancellationToken);

            if (goal == null) { throw new ArgumentNullException("Goal not found"); }

            var user = await _healthyUserRepository.GetByIdWithGoalsLevel(goal.User.Id, cancellationToken);

            if (user == null) { throw new ArgumentNullException("User not found"); }

            Progress progress; // _mapper.Map<Progress>(request);

            if (goal is DietGoal)
            {
                progress = _mapper.Map<DietProgress>(request);

                //var dietGoal = (DietGoal)goal;

                //dietGoal.AddDietProgress(progress);
            }
            else
            {
                progress = _mapper.Map<ExerciseProgress>(request);

                //var execirseGoal = (ExerciseGoal)goal;

                //execirseGoal.AddExerciseProgress(progress);
            }

            goal.AddProgress(progress);

            await _goalRepository.Update(goal, cancellationToken);

            if (user.ShouldLevelBeUpdated())
            {
                var nextLevel = await _levelRepository.GetById(user.Level.Id++, cancellationToken);

                user.Level = nextLevel;

                await _healthyUserRepository.Update(user, cancellationToken);
            }

            return _mapper.Map<ProgressResponse>(progress);
        }
    }
}