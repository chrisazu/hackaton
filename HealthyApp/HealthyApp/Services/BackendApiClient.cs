namespace HealthyApp.Services
{
    public class BackendApiClient
    {
        public HttpClient HttpClient { get; set; }

        public BackendApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            return HttpClient.BaseAddress.ToString();
        }
    }
}
