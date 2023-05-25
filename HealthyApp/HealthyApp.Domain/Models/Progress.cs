using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
	public class Progress
	{
		[Required]
        [Key]
        public int Id { get; set; }

		[Required]
		public TimeSpan Value { get; set; }		
	}
}
