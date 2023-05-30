namespace HealthyApp.Models.Requests
{
    public class ChatGptModel
    {
        public string Model { get; set; }

        public List<Message> Messages { get; set; }
    }
}
