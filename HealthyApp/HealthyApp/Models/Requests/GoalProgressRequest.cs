namespace HealthyApp.Models.Requests
{
    public class GoalProgressRequest
    {
        public required int GoalId { get; set; }

        public int Value { get; set; }
    }
}
