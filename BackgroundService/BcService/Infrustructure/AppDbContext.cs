using Microsoft.EntityFrameworkCore;

namespace BcService.Infrustructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }
}
