using Microsoft.EntityFrameworkCore;
using Post.Domain.Entity;

namespace Post.Application.Abstraction;

public interface IPostModelDbContext
{
    public DbSet<PostModel> Post { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);

}
