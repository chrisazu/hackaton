using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
    public class ExerciseProgress : Progress
    {
        [Required]
        public TimeSpan DurationInMinutes { get; set; }
    }
}
