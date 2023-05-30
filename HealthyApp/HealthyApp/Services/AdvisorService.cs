using System.Text;
using System.Text.Json;
using System.Web.Http;

using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

using Microsoft.AspNetCore.Http;

namespace HealthyApp.Services
{
    public class AdvisorService : IAdvisorService
    {

        private readonly ChatGptApiClient _chatGptClient;
        private readonly BackendApiClient _backApiClient;
        private readonly ILogger<GoalService> _logger;
        IHttpContextAccessor _httpContextAccessor;

        public AdvisorService(ChatGptApiClient chatGptClient, BackendApiClient backApiClient, ILogger<GoalService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _chatGptClient = chatGptClient;
            _backApiClient = backApiClient;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AskForRecomendations(AdviseRequest request)
        {
            try
            {
                HttpResponseMessage response = await _backApiClient.HttpClient.GetAsync($"user/{_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId").Value}/goals/{request.SelectedGoal}");

                if (response.IsSuccessStatusCode)
                {
                    GoalResponse goalResponse = await response.Content.ReadFromJsonAsync<GoalResponse>();

                    string message = CreateMessage(goalResponse);

                    ChatGptModel model = new ChatGptModel()
                    {
                        Model = "gpt-3.5-turbo",
                        Messages = new List<Message>()
                        {
                            new Message()
                            {
                                Role="system",
                                Content="You are ChatGPT, a large language model trained by OpenAI."
                            },
                            new Message()
                            {
                                Role="user",
                                Content=message
                            }
                        }
                    };


                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    requestMessage.Method = HttpMethod.Post;
                    requestMessage.Content = JsonContent.Create(model);


                    _chatGptClient.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "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");


                    HttpResponseMessage responseMessage = await _chatGptClient.HttpClient.SendAsync(requestMessage);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseString = await responseMessage.Content.ReadAsStringAsync();
                        {
                            if (!string.IsNullOrWhiteSpace(responseString))
                            {
                                var chatGptResponse = JsonSerializer.Deserialize<ChatGptResponse>(responseString);

                                request.MessageSent = message;
                                request.MessageReceived = chatGptResponse.choices.First().message.content.ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        private string CreateMessage(GoalResponse? goal)
        {
            string text = string.Empty;
            if (goal.Type != "Diet")
            {
                text = $"Mi objetivo es {goal.Type} por {goal.Duration}, {goal.TimesPerFrequency} veces por {goal.Frequency}";
            }
            else
            {
                text = $"Mi objetivo es bajar {goal.Kilograms} Kilogramos";
            }

            return text;
        }
    }
}
