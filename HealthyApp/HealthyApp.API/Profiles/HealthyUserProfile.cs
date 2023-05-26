using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Application.Models.Response;
using HealthyApp.Application.Services.HealthyUser.Commands;
using HealthyApp.Domain.Models;

namespace HealthyApp.API.Profiles
{
    public class HealthyUserProfile : Profile
    {
        public HealthyUserProfile()
        {
            CreateMap<UserRequest, CreateHealthyUserCommand>();
            CreateMap<User, HealthyUserResponse>();
            CreateMap<CreateHealthyUserCommand, User>();

            CreateMap<Level, LevelResponse>();
            
            CreateMap<Goal, GoalResponse>();

            CreateMap<Reward, RewardResponse>();

        }

    }
}
