namespace HealthyApp.Services
{
    public class ChatGptApiClient
    {
        private readonly HttpClient httpClient;

        public ChatGptApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            return httpClient.BaseAddress.ToString();
        }
    }
}
