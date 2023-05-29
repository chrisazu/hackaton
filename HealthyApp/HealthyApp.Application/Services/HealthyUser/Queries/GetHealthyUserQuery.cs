using HealthyApp.Application.Models.Response;
using MediatR;

namespace HealthyApp.Application.Services.HealthyUser.Queries
{
	public class GetHealthyUserQuery : IRequest<HealthyUserResponse>
	{
		public int Id { get; }
        public string AspNetUserId { get; }

        public GetHealthyUserQuery(int id)
		{
			Id = id;
		}

        public GetHealthyUserQuery(string aspNetUserId)
        {
            AspNetUserId = aspNetUserId;
        }
    }
}
