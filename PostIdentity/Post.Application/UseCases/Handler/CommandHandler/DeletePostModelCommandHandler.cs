using MediatR;
using Microsoft.EntityFrameworkCore;
using Post.Application.Abstraction;
using Post.Application.UseCases.Commands;
using Post.Domain.Entity;
using System.Security.Cryptography.X509Certificates;

namespace Post.Application.UseCases.Handler.CommandHandler;

public class DeletePostModelCommandHandler : IRequestHandler<DeletePostModelCommand, ResponseModel>
{
    private readonly IPostModelDbContext dbContext;

    public DeletePostModelCommandHandler(IPostModelDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ResponseModel> Handle(DeletePostModelCommand request, CancellationToken cancellationToken)
    {
        var model = await dbContext.Post.FirstOrDefaultAsync(x => x.Id == request.id);

        if (model is not null)
        {
            dbContext.Post.Remove(model);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                StatusCode = 200,
                Message = "succses",
                IsSuccess = true,
            };
        }

        return new ResponseModel
        {
            StatusCode = 401,
            Message = "Post not found"
        };
    }
}
