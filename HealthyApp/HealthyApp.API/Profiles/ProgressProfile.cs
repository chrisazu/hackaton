using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Domain.Models;
using HealthyApp.Application.Services.GoalProgress.Commands;
using HealthyApp.Application.Models.Response;

namespace HealthyApp.API.Profiles
{
	public class ProgressProfile : Profile
	{
        public ProgressProfile()
        {
			CreateMap<ProgressRequest, CreateProgressAndUpdateLevelCommand>()				
				.ForMember(m => m.Value, dest => dest.MapFrom(src => TimeSpan.FromMinutes(src.Value)));

			CreateMap<CreateProgressAndUpdateLevelCommand, Progress> ();

			CreateMap<Progress, ProgressResponse>();
		}
    }
}
