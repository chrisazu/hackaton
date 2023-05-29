using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;

using MediatR;

namespace HealthyApp.Application.Services.HealthyUser.Queries
{
    public class GetHealthyUserQueryHandler : IRequestHandler<GetHealthyUserQuery, HealthyUserResponse>
    {
        private readonly IHealthyUserRepository _healthyUserRepository;
        private readonly IMapper _mapper;

        public GetHealthyUserQueryHandler(IHealthyUserRepository healthyUserRepository, IMapper mapper)
        {
            _healthyUserRepository = healthyUserRepository;
            _mapper = mapper;
        }

        public async Task<HealthyUserResponse> Handle(GetHealthyUserQuery request, CancellationToken cancellationToken)
        {
            Domain.Models.User user;

            if (request.AspNetUserId == null)
            {
                user = await _healthyUserRepository.GetById(request.Id, cancellationToken);                
            }
            else
            {
                user = await _healthyUserRepository.GetByAspNetUserIdWithLevel(request.AspNetUserId, cancellationToken);
            }

            return _mapper.Map<HealthyUserResponse>(user);
        }
    }
}
