namespace HealthyApp.Models.Requests
{
    public class AddProgress
    {
        public int GoalId { get; set; }

        public int Value { get; set; }

        public int TimeType { get; set; } = 1;
    }
}
