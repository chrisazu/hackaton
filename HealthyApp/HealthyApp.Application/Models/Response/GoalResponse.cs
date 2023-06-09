﻿namespace HealthyApp.Application.Models.Response
{
	public class GoalResponse
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Type { get; set; }

		public int Status { get; private set; }

		public string Frequency { get; set; }

		public int TimesPerFrequency { get; set; }

        public int Kilograms { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<ProgressResponse> Progresses { get; set; }
    }
}