using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;

using MediatR;

namespace HealthyApp.Application.Services.Goals.Queries
{
    public class GetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, GoalResponse>
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GetGoalByIdQueryHandler(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<GoalResponse> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetByIdWithUserProgress(request.Id, cancellationToken);

            return _mapper.Map<GoalResponse>(goal);
        }
    }
}
