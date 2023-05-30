using HealthyApp.Domain.Models;

namespace HealthyApp.Application.Models.Response
{
	public class ProgressResponse
	{
		public int Id { get; set; }

        public TimeSpan Value { get; set; }

        public int KilogramsLost { get; set; }

        public TimeSpan DurationInMinutes { get; set; }

        public Level NewLevel { get; set; }
    }
}
