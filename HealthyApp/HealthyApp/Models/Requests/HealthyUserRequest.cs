namespace HealthyApp.Models.Requests
{
    public class HealthyUserRequest
    {
        public string AspNetUserId { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }
    }
}
