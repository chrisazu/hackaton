﻿namespace HealthyApp.Application.Models.Response
{
	public class ProgressResponse
	{
		public int Id { get; set; }

        public TimeSpan Value { get; set; }

        public TimeSpan DurationInMinutes { get; set; }
    }
}
