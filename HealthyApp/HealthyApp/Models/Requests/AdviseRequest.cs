namespace HealthyApp.Models.Requests
{
    public class AdviseRequest
    {
        public int SelectedGoal { get; set; }

        public string MessageSent { get; set; }

        public string MessageReceived { get; set; } = string.Empty;
    }
}
