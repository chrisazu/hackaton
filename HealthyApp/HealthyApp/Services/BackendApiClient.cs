namespace HealthyApp.Services
{
    public class BackendApiClient
    {
        private readonly HttpClient httpClient;

        public BackendApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            return httpClient.BaseAddress.ToString();
        }
    }
}
