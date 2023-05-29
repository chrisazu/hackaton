using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HealthyApp.Domain.Enums;

namespace HealthyApp.Application.Models.Requests
{
    public class GoalRequest
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Type { get; set; }

        public required string Frequency { get; set; }

        public int TimesPerFrequency { get; set; } = 0;

        public int DurationInMinutes { get; set; } = default;

        public int Kilograms { get; set; }
    }
}
