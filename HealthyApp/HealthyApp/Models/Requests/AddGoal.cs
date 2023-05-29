namespace HealthyApp.Models.Requests
{
    public class AddGoal
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Status { get; private set; }

        public string Frequency { get; set; }

        public int TimesPerFrequency { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
