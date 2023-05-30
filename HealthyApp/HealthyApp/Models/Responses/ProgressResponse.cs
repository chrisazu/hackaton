namespace HealthyApp.Models.Responses
{
    public class ProgressResponse
    {
        public int Id { get; set; }

        public TimeSpan Value { get; set; }

        public int KilogramsLost { get; set; }
    }
}
