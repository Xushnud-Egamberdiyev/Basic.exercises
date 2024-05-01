using Discount.Application.DiscountCases.Commands;
using Discount.Application.DiscountCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]

        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllDiscount()
        {
            var result = await _mediator.Send(new GetAllDiscountQuery());
            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteDiscount(DeleteDiscountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
