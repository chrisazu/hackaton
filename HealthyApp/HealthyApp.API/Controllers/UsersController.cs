using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Application.Services.HealthyUser.Commands;
using HealthyApp.Application.Services.HealthyUser.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HealthyApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly ISender _sender;
		private readonly IMapper _mapper;

		public UsersController(ISender sender, IMapper mapper)
		{
			_sender = sender;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public async Task<IResult> GetUser(int id)
		{
			try
			{
				var command = new GetHealthyUserQuery(id);
				var response = await _sender.Send(command);

				return response is not null ? Results.Ok(response) : Results.NoContent();
			}
			catch (Exception ex)
			{
				return Results.BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IResult> PostUser(UserRequest userRequest)
		{
			try
			{
				var command = _mapper.Map<CreateHealthyUserCommand>(userRequest);
				var response = await _sender.Send(command);

				return response is not null ? Results.Ok(response) : Results.NoContent();
			}
			catch (Exception ex)
			{
				return Results.BadRequest(ex.Message);
			}
		}
	}
}
