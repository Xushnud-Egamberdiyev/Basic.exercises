using Discount.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Abstractions
{
    public interface IDiscountDbContext
    {
       public DbSet<DiscountModel> Discounts { get; set; }
       public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
