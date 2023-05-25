using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
	public class Progress
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public TimeSpan Value { get; set; }		
	}
}
