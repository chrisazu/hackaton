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

        public User()
        {
            Goals = new List<Goal>();
        }

		public void UpdateLevel()
		{
			if (Goals != null)
			{
				Goals.All(a => a.Status == Enums.GoalStatus.Accomplished);
				//Level.id ++
			}
		}
    }
}
