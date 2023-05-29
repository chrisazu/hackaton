using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Domain.Models
{
    public class DietProgress : Progress
    {
        [Required]
        public int KilogramsLost { get; set; }
    }
}
