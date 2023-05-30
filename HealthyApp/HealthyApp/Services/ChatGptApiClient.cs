namespace HealthyApp.Services
{
    public class ChatGptApiClient
    {
        public HttpClient HttpClient { get; set; }

        public ChatGptApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            return HttpClient.BaseAddress.ToString();
        }
    }
}
