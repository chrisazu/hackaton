﻿using AutoMapper;
using HealthyApp.Models.Requests;
using HealthyApp.Areas.Identity.Pages.Account;
using static HealthyApp.Areas.Identity.Pages.Account.RegisterModel;

namespace HealthyApp.Profiles
{
    public class HealthyUserProfile : Profile
    {
        public HealthyUserProfile()
        {
            CreateMap<InputModel, HealthyUserRequest>();
        }
    }
}
