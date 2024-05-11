using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.Application.Abstraction;
using Post.Application.UseCases.Commands;
using Post.Application.UseCases.Query;
using Post.Domain.Entity;

namespace PostIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostModelDbContext context;
        private readonly IMediator mediator;

        public PostController(IPostModelDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;   
        }

        [HttpPost]
        public Task<ResponseModel> CreatePost(CreatePostModelCommand model)
        {
            var result = mediator.Send(model);
            return result;
        }

        [HttpGet]
        public Task<IEnumerable<PostModel>> PostModel()
        {
            var result = mediator.Send(new GetAllPostQuery());

            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModel(DeletePostModelCommand deletePostModelCommand)
        {
            var model = mediator.Send(deletePostModelCommand);

            return Ok(model);
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateCompanyCategory(UpdatePostModelCommamd request)
        {
            var result = await mediator.Send(request);
            return result;
        }
    }
}
