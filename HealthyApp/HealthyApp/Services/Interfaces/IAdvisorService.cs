using HealthyApp.Models.Requests;

namespace HealthyApp.Services.Interfaces
{
    public interface IAdvisorService
    {
        Task AskForRecomendations(AdviseRequest request);
    }
}
