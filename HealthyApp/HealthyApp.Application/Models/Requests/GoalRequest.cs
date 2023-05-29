namespace HealthyApp.Application.Models.Requests
{
    public class GoalRequest
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Type { get; set; }

        public int Frequency { get; set; }

        public int TimesPerFrequency { get; set; } = 0;

        public int DurationInMinutes { get; set; } = default;

        public int Kilograms { get; set; }
    }
}
