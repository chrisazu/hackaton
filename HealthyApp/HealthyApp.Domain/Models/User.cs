using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string AspNetUserId { get; set; }

		[Required]
		[StringLength(100)]
		public required string Name { get; set; }

		[Required]
		[StringLength(100)]
		public required string LastName { get; set; }

		public List<Goal> Goals { get; set; }

		[Required]
		public required Level Level { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public User()
		{
			Goals = new List<Goal>();
		}


		public bool ShouldLevelBeUpdated()
		{
			if (Goals != null)
			{
				if (Goals.All(a => a.Status == Enums.GoalStatus.Accomplished))
				{
					return true;
				}
			}

			return false;
		}
	}
}
