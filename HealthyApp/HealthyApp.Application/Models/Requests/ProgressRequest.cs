namespace HealthyApp.Application.Models.Requests
{
    public class ProgressRequest
    {
        public int Value { get; set; } = default;

        public int Kilograms { get; set; }
    }
}
