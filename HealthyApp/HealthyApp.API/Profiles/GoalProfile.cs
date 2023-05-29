using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Application.Services.Goals.Commands;
using HealthyApp.Domain.Enums;
using HealthyApp.Domain.Models;

namespace HealthyApp.API.Profiles
{
	public class GoalProfile : Profile
    {
        public GoalProfile()
        {
            CreateMap<GoalRequest, CreateGoalCommand>()
                .ForMember(m => m.Frequency, dest => dest.MapFrom(src => Enum.GetName(typeof(GoalFrequency), src.Frequency)))
                .ForMember(m => m.Type, dest => dest.MapFrom(src => Enum.GetName(typeof(GoalType), src.Type)))
                .ForMember(m => m.Kilograms, dest => dest.MapFrom(src => src.Kilograms))
                .ForMember(m => m.Duration, dest => dest.MapFrom(src => TimeSpan.FromMinutes(src.DurationInMinutes)));

            CreateMap<CreateGoalCommand, Goal>()
                .ForMember(m => m.Type, dest => dest.MapFrom(src => (GoalType)Enum.Parse(typeof(GoalType), src.Type)));
        }
    }
}
