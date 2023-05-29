using HealthyApp.Domain.Enums;

namespace HealthyApp.Application.Models.Requests
{
    public class GoalRequest
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required GoalType Type { get; set; }

        public int Frequency { get; set; }

        public int TimesPerFrequency { get; set; } = 0;

        public int DurationInMinutes { get; set; } = default;

        public int Kilograms { get; set; }
    }
}
