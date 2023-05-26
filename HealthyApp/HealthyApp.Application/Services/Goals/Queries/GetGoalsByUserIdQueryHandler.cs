using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;

using MediatR;

namespace HealthyApp.Application.Services.Goals.Queries
{
    public class GetGoalsByUserIdQueryHandler : IRequestHandler<GetGoalsByUserIdQuery, IEnumerable<GoalResponse>>
    {

        private readonly IHealthyUserRepository _healthyUserRepository;
        private readonly IMapper _mapper;

        public GetGoalsByUserIdQueryHandler(IHealthyUserRepository healthyUserRepository, IMapper mapper)
        {
            _healthyUserRepository = healthyUserRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GoalResponse>> Handle(GetGoalsByUserIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _healthyUserRepository.GetById(request.UserId, cancellationToken);


            if (user == null) { return Enumerable.Empty<GoalResponse>(); }

            var goals = _mapper.Map<IEnumerable<GoalResponse>>(user.Goals);


            return goals;
        }
    }
}
