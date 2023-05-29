using HealthyApp.Domain.Enums;

namespace HealthyApp.Domain.Models
{
    public class DietGoal : Goal
    {
        public int Kilograms { get; set; }

        public virtual List<DietProgress> Progresses { get; private set; }

        public override void AddProgress(Progress goalProgress)
        {
            Progresses ??= new List<DietProgress>();

            Progresses.Add((DietProgress)goalProgress);

            Status = GoalStatus.OnProgress;

            if (Progresses.Sum(s => s.KilogramsLost) >= Kilograms)
            {
               Status = GoalStatus.Accomplished;
            }
        }
    }
}
