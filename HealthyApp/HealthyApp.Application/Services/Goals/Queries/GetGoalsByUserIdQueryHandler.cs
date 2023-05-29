using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using MediatR;

namespace HealthyApp.Application.Services.Goals.Queries
{
    public class GetGoalsByUserIdQueryHandler : IRequestHandler<GetGoalsByUserIdQuery, IEnumerable<GoalResponse>>
    {   
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GetGoalsByUserIdQueryHandler(IGoalRepository goalRepository, IMapper mapper)
        {   
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GoalResponse>> Handle(GetGoalsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var goals = await _goalRepository.GetByUserId(request.UserId, cancellationToken);

            var pepe = new List<GoalResponse>();

            foreach (var userGoal in goals)
            {
                if (userGoal is ExerciseGoal)
                {
                    var asd = userGoal as ExerciseGoal;

                    pepe.Add(_mapper.Map<GoalResponse>(asd));
                }

                if (userGoal is DietGoal)
                {
                    var asd = userGoal as DietGoal;

                    pepe.Add(_mapper.Map<GoalResponse>(asd));
                }
            }

            //return _mapper.Map<IEnumerable<GoalResponse>>(goals);
            return pepe;
        }
    }
}
