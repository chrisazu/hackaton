using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Application.Services.GoalProgress.Commands;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HealthyApp.API.Controllers
{
	[Route("api/goal/{goalId}/[controller]")]
	[ApiController]
	public class ProgressController : ControllerBase
	{
		private readonly ISender _sender;
		private readonly IMapper _mapper;

		public ProgressController(ISender sender, IMapper mapper)
		{
			_sender = sender;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IResult> PostProgress([FromRoute] int goalId, ProgressRequest progressRequest)
		{
			try
			{
				var command = _mapper.Map<CreateProgressAndUpdateLevelCommand>(progressRequest);

				command.GoalId = goalId;

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
