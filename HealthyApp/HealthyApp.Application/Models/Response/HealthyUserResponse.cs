namespace HealthyApp.Application.Models.Response
{
	public class HealthyUserResponse
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public List<GoalResponse> Goals { get; set; }

		public LevelResponse Level { get; set; }
	}
}
