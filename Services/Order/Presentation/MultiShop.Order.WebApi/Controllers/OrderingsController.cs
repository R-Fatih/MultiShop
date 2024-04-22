using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderings()
        {

            var result = await _mediator.Send(new GetOrderingQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var result = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
             await _mediator.Send(command);
            return Ok("Created succesfully");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated succesfully");
        }
        [HttpGet("Remove/{id}")]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Deleted succesfully");
        }
        [HttpGet("GetOrderingByUserId")]
        public async Task<IActionResult> GetOrderingByUserId(string userId)
        {
            var result = await _mediator.Send(new GetOrderingByUserIdQuery(userId));
            return Ok(result);
        }
    }
}
