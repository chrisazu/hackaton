namespace HealthyApp.Models.Responses
{
    public class GoalResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string LabelType
        {
            get
            {
                switch (Type)
                {
                    case "Jogging":
                        return "Hacer ejercicio";
                    case "Diet":
                        return $"Bajar {Kilograms} kg de peso";
                    default:
                        return "Meditar";
                }
            }
        }

        public bool IsDiet { get { return Type == "Diet"; } }

        public int Status { get; set; }

        public string LabelStatus
        {
            get
            {
                switch (Status)
                {
                    case 1:
                        return "Planeado 📕";
                    case 2:
                        return "En progreso ⏳";
                    default:
                        return "Cumplido ✔";
                }
            }
        }

        public bool IsGoalAccomplished { get { return Status == 3; } }

        public string Frequency { get; set; }

        public string LabelFrequency
        {
            get
            {
                switch (Frequency)
                {
                    case "Daily":
                        return "día";
                    case "Weekly":
                        return "semana";
                    case "Monthly":
                        return "mes";
                    default:
                        return "año";
                }
            }
        }

        public int TimesPerFrequency { get; set; }

        public string LabelTimesPerFrequency { get { return $"{TimesPerFrequency} veces por {LabelFrequency}"; } }

        public int Kilograms { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LabelDuration { get { return $"{Duration.TotalMinutes} minutos"; } }

        public List<ProgressResponse> Progresses { get; set; }

        public string ShowProgress
        {
            get
            {
                switch (Type)
                {
                    case "Diet":
                        {
                            var total = Progresses?.Sum(p => p.KilogramsLost);

                            var dif = Kilograms - total;

                            if (dif <= 0)
                            {
                                return "¡Lo lograste, cumpliste con el objetivo!😁";
                            }

                            return $"{total} kilos (vamos que sólo faltan {dif} kilos) 💪";
                        }
                    default:
                        {
                            var total = Progresses?.Sum(p => p.Value.Duration().TotalMinutes);

                            var dif = Duration.TotalMinutes * TimesPerFrequency - total;

                            if (dif <= 0)
                            {
                                return "¡Lo lograste, cumpliste con el objetivo!😁";
                            }

                            return $"{total} minutos (vamos que sólo faltan {dif} minutos/{LabelFrequency}) 💪";
                        }
                }
            }
        }
    }
}