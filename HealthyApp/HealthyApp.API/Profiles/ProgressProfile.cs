using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Application.Models.Response;
using HealthyApp.Application.Services.GoalProgress.Commands;
using HealthyApp.Domain.Models;

namespace HealthyApp.API.Profiles
{
    public class ProgressProfile : Profile
    {
        public ProgressProfile()
        {
            CreateMap<ProgressRequest, CreateProgressAndUpdateLevelCommand>()
                .ForMember(m => m.Value, dest => dest.MapFrom(src => TimeSpan.FromMinutes(src.Value)));

            CreateMap<CreateProgressAndUpdateLevelCommand, Progress>()
                .Include<CreateProgressAndUpdateLevelCommand, DietProgress>()
                .Include<CreateProgressAndUpdateLevelCommand, ExerciseProgress>();

            CreateMap<Progress, ProgressResponse>();

            CreateMap<DietProgress, ProgressResponse>()
                .ForMember(m => m.KilogramsLost, dest => dest.MapFrom(src => src.KilogramsLost));

            CreateMap<ExerciseProgress, ProgressResponse>()
                .ForMember(m => m.Value, dest => dest.MapFrom(src => src.DurationInMinutes));

            CreateMap<CreateProgressAndUpdateLevelCommand, DietProgress>()
                .ForMember(m => m.KilogramsLost, dest => dest.MapFrom(src => src.Value));

            CreateMap<CreateProgressAndUpdateLevelCommand, ExerciseProgress>()
                .ForMember(m => m.DurationInMinutes, dest => dest.MapFrom(src => TimeSpan.FromMinutes(src.Value)));
        }
    }
}
