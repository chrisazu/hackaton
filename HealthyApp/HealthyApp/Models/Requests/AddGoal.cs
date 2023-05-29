using System.ComponentModel.DataAnnotations;

namespace HealthyApp.Models.Requests
{
    public class AddGoalRequest
    {
        [Required(ErrorMessage = "Ey, te faltó el nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ey, te faltó la descripción")]
        public string Description { get; set; }
                
        public string Type { get; set; }
                
        public string Frequency { get; set; }

        public int TimesPerFrequency { get; set; }

        public int DurationInMinutes { get; set; }

        public int Kilograms { get; set; }

        public int UserId { get; set; }
    }
}
