using AutoMapper;

using HealthyApp.Application.Models.Requests;
using HealthyApp.Application.Models.Response;
using HealthyApp.Application.Services.Goals.Commands;
using HealthyApp.Application.Services.Goals.Queries;
using HealthyApp.Domain.Models;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HealthyApp.API.Controllers
{
    [Route("api/Users/{userId}/[controller]")]
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
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IResult> GetGoals(int userId)
        {
            var query = new GetGoalsByUserIdQuery(userId);

            IEnumerable<GoalResponse> response = await _sender.Send(query);

            return Results.Ok(response);
        }

       
        [HttpPost]
        public async Task<IResult> CreateGoal(int userId, GoalRequest request)
        {
            var command = _mapper.Map<CreateGoalCommand>(request);

            command.UserId = userId;

            GoalResponse response = await _sender.Send(command);

            return Results.Ok(response);

        }
       
    }
}
