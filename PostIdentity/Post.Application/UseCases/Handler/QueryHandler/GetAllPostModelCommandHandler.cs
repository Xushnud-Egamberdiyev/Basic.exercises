using MediatR;
using Microsoft.EntityFrameworkCore;
using Post.Application.Abstraction;
using Post.Application.UseCases.Query;
using Post.Domain.Entity;

namespace Post.Application.UseCases.Handler.QueryHandler;

public class GetAllPostModelCommandHandler : IRequestHandler<GetAllPostQuery, IEnumerable<PostModel>>
{
    private readonly IPostModelDbContext dbContext;

    public GetAllPostModelCommandHandler(IPostModelDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<PostModel>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Post.ToListAsync(cancellationToken);

        return result;
    }
}
