namespace HealthyApp.Models.Responses
{
	public class GoalResponse
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Type { get; set; }

		public bool IsDiet { get { return Type == "Diet"; } }

        public string Status { get; private set; }

		public string Frequency { get; set; }

        public string GetLabelFrequency { get { return $"{Frequency}";  } }

        public int TimesPerFrequency { get; set; }

        public string GetLabelTimesPerFrequency { get { return $"{TimesPerFrequency} veces"; } }

        public int Kilograms { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreatedDate { get; set; }

        public string GetLabelDuration { get { return $"{Duration} horas"; } }

        public List<ProgressResponse> Progesses { get; set; }
    }
}