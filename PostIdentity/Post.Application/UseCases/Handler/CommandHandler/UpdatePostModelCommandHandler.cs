using MediatR;
using Microsoft.EntityFrameworkCore;
using Post.Application.Abstraction;
using Post.Application.UseCases.Commands;
using Post.Domain.Entity;

namespace Post.Application.UseCases.Handler.CommandHandler;

public class UpdatePostModelCommandHandler : IRequestHandler<UpdatePostModelCommamd, ResponseModel>
{
    private readonly IPostModelDbContext dbContext;

    public UpdatePostModelCommandHandler(IPostModelDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ResponseModel> Handle(UpdatePostModelCommamd request, CancellationToken cancellationToken)
    {
        var model = await dbContext.Post.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (model is not null)
        {
            model.Title = request.Title;
            model.Description = request.Description;

            dbContext.Post.Update(model);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                StatusCode = 200,
                Message = "Post updated",
                IsSuccess = true
            };

        }

        return new ResponseModel
        {
            StatusCode = 401,
            Message = "This company not registered yet!"
        };
    }
}
