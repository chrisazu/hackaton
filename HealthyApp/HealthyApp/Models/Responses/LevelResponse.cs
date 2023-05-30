using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Models.Responses
{
	public class LevelResponse
	{
		public int Id { get; set; }

		public int Number { get; set; } = 1;

		public string Name { get; set; }

		public string Description { get; set; }

        public string Url { get; set; }

        public virtual List<RewardResponse> Rewards { get; set; }
	}
}