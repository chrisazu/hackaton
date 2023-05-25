using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
	public class Reward
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public required string Name { get; set; }

		[Required]
		[StringLength(100)]
		public required string Description { get; set; }
	}
}
