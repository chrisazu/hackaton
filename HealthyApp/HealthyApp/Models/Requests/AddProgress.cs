namespace HealthyApp.Models.Requests
{
    public class AddProgress
    {
        public int GoalId { get; set; }

        public int DurationInMinutes { get; set; }

        public TimeType TimeType { get; set; }
    }
}
