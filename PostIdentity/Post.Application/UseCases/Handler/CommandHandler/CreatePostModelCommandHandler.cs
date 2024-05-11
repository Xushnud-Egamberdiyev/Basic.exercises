using MediatR;
using Post.Application.Abstraction;
using Post.Application.UseCases.Commands;
using Post.Domain.Entity;

namespace Post.Application.UseCases.Handler.CommandHandler;

public class CreatePostModelCommandHandler : IRequestHandler<CreatePostModelCommand, ResponseModel>
{
    private readonly IPostModelDbContext dbContext;

    public CreatePostModelCommandHandler(IPostModelDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ResponseModel> Handle(CreatePostModelCommand request, CancellationToken cancellationToken)
    {
        if(request is not null)
        {
            var model = new PostModel
            {
                Title = request.Title,
                Description = request.Description
            };

             await dbContext.Post.AddAsync(model, cancellationToken);
             await dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = "Created",
                StatusCode = 200,
                IsSuccess = true
            };
        }

        return new ResponseModel
        {
            Message = $"{request.Title} is null",
            StatusCode = 404
        };
    }
}
