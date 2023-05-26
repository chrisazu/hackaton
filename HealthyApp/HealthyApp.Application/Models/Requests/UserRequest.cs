namespace HealthyApp.Application.Models.Requests
{
	public class UserRequest
    {
        public required string AspNetUserId { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }
    }
}
