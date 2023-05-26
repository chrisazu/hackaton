using AutoMapper;

using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using MediatR;

namespace HealthyApp.Application.Services.GoalProgress.Commands
{
	public class CreateProgressCommandHandler : IRequestHandler<CreateProgressCommand, ProgressResponse>
    {
        private readonly IProgressRepository _progressRepository;
        private readonly IMapper _mapper;

        public CreateProgressCommandHandler(IProgressRepository progressRepository, IMapper mapper, ILevelRepository levelRepository)
        {
            _progressRepository = progressRepository;
            _mapper = mapper;
        }

        public async Task<ProgressResponse> Handle(CreateProgressCommand request, CancellationToken cancellationToken)
        {
            var progress = _mapper.Map<Progress>(request);

            await _progressRepository.Create(progress, cancellationToken);

            return _mapper.Map<ProgressResponse>(progress);
        }
    }
}