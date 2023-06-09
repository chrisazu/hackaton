﻿using AutoMapper;

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

            var goalResponse = new List<GoalResponse>();

            foreach (var userGoal in goals)
            {
                if (userGoal is ExerciseGoal)
                {
                    goalResponse.Add(_mapper.Map<GoalResponse>(userGoal as ExerciseGoal));
                }

                if (userGoal is DietGoal)
                {
                    goalResponse.Add(_mapper.Map<GoalResponse>(userGoal as DietGoal));
                }
            }

            return goalResponse;
        }
    }
}
