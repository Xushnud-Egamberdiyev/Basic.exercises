using Microsoft.EntityFrameworkCore;
using Post.Application.Abstraction;
using Post.Domain.Entity;

namespace Post.Infrastructor.Persistence;

public class AbbDbContext : DbContext, IPostModelDbContext
{
    public AbbDbContext(DbContextOptions<AbbDbContext> options) : base(options) { }

    public DbSet<PostModel> Post { get; set; }
}
