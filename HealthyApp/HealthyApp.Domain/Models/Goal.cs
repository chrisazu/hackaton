using System.ComponentModel.DataAnnotations;
using HealthyApp.Domain.Enums;

namespace HealthyApp.Domain.Models
{
    public class Goal
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
		public required GoalStatus GoalStatus { get; set; }

		public virtual required User User { get; set; }
	}
}
