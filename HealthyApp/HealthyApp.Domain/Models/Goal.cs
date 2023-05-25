using HealthyApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
	public class Goal
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public required string Name { get; set; }

		[Required]
		[StringLength(100)]
		public required string Description { get; set; }

		[Required]
		public required GoalType Type { get; set; }

		[Required]
		public GoalStatus Status { get; private set; }

		[Required]
		public required GoalFrequency Frequency { get; set; }

		public int TimesPerFrequency { get; set; } = 0;

		public TimeSpan Duration { get; set; } = default;

		public virtual required User User { get; set; }

		public virtual List<Progress> Progresses { get; private set; }

		public void AddProgress(Progress goalProgress)
		{
			Progresses ??= new List<Progress>();

			Progresses.Add(goalProgress);

			Status = GoalStatus.OnProgress;

			if (Progresses.Sum(s => s.Value.TotalHours) >= Duration.TotalHours)
			{
				Status = GoalStatus.Accomplished;
			}			
		}
    }
}

// yo hago dieta para bajar 5 kilos por mes -> type: diet | frequency: monthly | frequency times: 0 | duration: 1 month
// ejercicio 3 veces por semana -> yo hago ejercicio 1 hora 3 veces por semana -> type: jogging | frequency: weekly | frequency times: 3 | duration: 1 h
// medito todos los dias -> yo metido 40 min 3 veces por semana -> type: meditation | frequency: weekly | insitive: 3 | duration: 40 m


// Nivel 1: Caminar 10 horas por semana.
// Nivel 2: Caminar 10 horas y Meditar 3 horas.
// Nivel 3: Dieta un día, caminar 2 horas y meditar 1 hora.

