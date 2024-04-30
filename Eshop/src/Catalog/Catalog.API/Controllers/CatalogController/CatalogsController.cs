using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Application.UseCases.CatalogCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.CatalogController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CatalogsController(IMediator mediator)
        {
             _mediator = mediator;
        }


        [HttpPost]
        public async  Task<IActionResult> CreateCatalog(CreateCatalogCommand command)
        {
           var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCatalogs()
        {
            var result = await _mediator.Send(new GetAllCatalogsQuery());
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCatalog(UpdateCatalogCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCatalog(DeleteCatalogCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
