using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Application.Models.Response
{
	public class LevelResponse
	{
		public int Id { get; set; }

		public int Number { get; set; } = 1;

		public string Name { get; set; }

		public string Description { get; set; }

        public string Url { get; set; }

        public List<RewardResponse> Rewards { get; set; }
	}
}