﻿using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
	public class Level
	{
		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		public int Number { get; set; } = 1;

		[Required]
		public string Name { get; set; }

		internal decimal Multiplier(int prevGoalValue) => prevGoalValue * (1 + Number / 10);

		public string Description { get; set; }

		public virtual List<Reward> Rewards { get; set; }

		public string Url { get; set; }
	}
}