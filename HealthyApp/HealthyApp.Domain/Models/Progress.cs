using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
    public abstract class Progress
    {
        [Required]
        [Key]
        public int Id { get; set; }        

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
