namespace HealthyApp.Models.Requests
{
    public class GoalProgressRequest
    {
        public required int GoalId { get; set; }

        public required int DurationInMinutes { get; set; }
    }
}
