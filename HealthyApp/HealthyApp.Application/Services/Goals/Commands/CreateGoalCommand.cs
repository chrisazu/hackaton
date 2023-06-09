﻿using HealthyApp.Application.Models.Response;
using HealthyApp.Domain.Enums;

using MediatR;

namespace HealthyApp.Application.Services.Goals.Commands
{
    public class CreateGoalCommand : IRequest<GoalResponse>
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public GoalType Type { get; set; }

        public required GoalFrequency Frequency { get; set; }

        public int TimesPerFrequency { get; set; } = 0;

        public TimeSpan Duration { get; set; } = default;

        public int Kilograms { get; set; } = 0;

        public int UserId { get; set; }
    }
}
