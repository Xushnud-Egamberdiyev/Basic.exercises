using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEasy.Data.DbContexts;
using TheEasy.Data.IRepositories;
using TheEasy.Domain.Command;

namespace TheEasy.Data.Repositories;

public class Repository<Entity> : IRepository<Entity> where Entity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<Entity> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = this.dbContext.Set<Entity>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var result = await this.dbSet.FirstOrDefaultAsync(u => u.Id == id);
        this.dbSet.Remove(result);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Entity> InsertAsync(Entity entitiy)
    {
        var result = (await this.dbSet.AddAsync(entitiy)).Entity;
        await this.dbContext.SaveChangesAsync();

        return result;
    }

    public IQueryable<Entity> SelectAll() =>
           this.dbSet;
    

    public async Task<Entity> SelectByIdAsync(long id)
    {
        return await this.dbSet.FirstOrDefaultAsync(u => u.Id ==id);
    }

    public async Task<Entity> UpdateAsync(Entity entitiy)
    {
        var result = this.dbSet.Update(entitiy);

        await this.dbContext.SaveChangesAsync();
        return result.Entity;
    }
}
