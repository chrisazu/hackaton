using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Application.Models.Response;
using HealthyApp.Application.Services.Goals.Commands;
using HealthyApp.Application.Services.Goals.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HealthyApp.API.Controllers
{
    [Route("api/user/{userId}/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public GoalsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> GetGoals(int userId)
        {
            try
            {
                var query = new GetGoalsByUserIdQuery(userId);

                IEnumerable<GoalResponse> response = await _sender.Send(query);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }


        [HttpGet("{goalId}")]
        public async Task<IResult> GetById([FromRoute] int goalId)
        {
            try
            {
                var query = new GetGoalByIdQuery(goalId);

                GoalResponse response = await _sender.Send(query);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> CreateGoal([FromRoute] int userId, GoalRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateGoalCommand>(request);

                command.UserId = userId;

                GoalResponse response = await _sender.Send(command);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}