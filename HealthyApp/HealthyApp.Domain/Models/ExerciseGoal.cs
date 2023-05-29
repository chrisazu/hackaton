using System.ComponentModel.DataAnnotations;

using HealthyApp.Domain.Enums;

namespace HealthyApp.Domain.Models
{
    public class ExerciseGoal : Goal
    {
        [Required]
        public GoalFrequency Frequency { get; set; }

        public int TimesPerFrequency { get; set; } = 0;

        public TimeSpan Duration { get; set; }

        public virtual List<ExerciseProgress> Progresses { get; private set; }

        public override void AddProgress(Progress goalProgress)
        {
            Progresses ??= new List<ExerciseProgress>();

            Status = GoalStatus.OnProgress;

            Progresses.Add((ExerciseProgress)goalProgress);

            if (Progresses.Sum(s => s.DurationInMinutes.TotalHours) >= Duration.TotalHours * TimesPerFrequency)
            {
                Status = GoalStatus.Accomplished;
            }
        }
    }
}
