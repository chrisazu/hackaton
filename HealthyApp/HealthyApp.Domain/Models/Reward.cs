using System.ComponentModel.DataAnnotations;
using HealthyApp.Domain.Enums;

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

		[Required]
		public required RewardStatus RewardStatus { get; set; }
	}
}
