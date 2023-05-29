using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
    public class Progress
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public TimeSpan Value { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
