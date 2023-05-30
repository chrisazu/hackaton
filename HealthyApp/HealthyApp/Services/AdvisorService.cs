using System.Text.Json;

using HealthyApp.Models.Requests;
using HealthyApp.Models.Responses;
using HealthyApp.Services.Interfaces;

namespace HealthyApp.Services
{
    public class AdvisorService : IAdvisorService
    {
        private readonly ChatGptApiClient _chatGptClient;
        private readonly BackendApiClient _backApiClient;
        private readonly ILogger<GoalService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public AdvisorService(ChatGptApiClient chatGptClient, BackendApiClient backApiClient, ILogger<GoalService> logger, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _chatGptClient = chatGptClient;
            _backApiClient = backApiClient;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
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

                    ChatGptModel model = new()
                    {
                        Model = _config.GetSection("AI").GetValue<string>("model"),
                        Messages = new List<Message>()
                        {
                            new Message()
                            {
                                Role = "system",
                                Content = _config.GetSection("AI").GetValue<string>("role")
                            },
                            new Message()
                            {
                                Role = "user",
                                Content = message
                            }
                        }
                    };

                    HttpRequestMessage requestMessage = new()
                    {
                        Method = HttpMethod.Post,
                        Content = JsonContent.Create(model)
                    };

                    _chatGptClient.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config.GetSection("AI").GetValue<string>("token"));

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
            if (goal.IsDiet)
            {
                return $"Mi objetivo es bajar {goal.Kilograms} Kilogramos";
            }
            else
            {
                return $"Mi objetivo es {goal.LabelType} por {goal.LabelDuration} {goal.LabelTimesPerFrequency}";                
            }
        }
    }
}
