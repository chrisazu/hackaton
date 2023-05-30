using System.ComponentModel.DataAnnotations;

using HealthyApp.Domain.Enums;

namespace HealthyApp.Domain.Models
{
    public abstract class Goal
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
        public GoalType Type { get; set; }

        [Required]
        public GoalStatus Status { get; set; } = GoalStatus.Planned;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; }

        public abstract void AddProgress(Progress goalProgress);
    }
}