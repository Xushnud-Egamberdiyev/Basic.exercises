using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEasy.Data.IRepositories;

public interface IRepository<Entitiy>
{
    public Task<Entitiy> SelectByIdAsync(long id);
    public IQueryable<Entitiy> SelectAll();
    public Task<Entitiy> InsertAsync(Entitiy entitiy);
    public Task<Entitiy> UpdateAsync(Entitiy entitiy);
    public Task<bool> DeleteAsync(long id);
}
