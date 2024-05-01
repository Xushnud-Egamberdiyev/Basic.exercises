using Discount.Application.Abstractions;
using Discount.Application.DiscountCases.Queries;
using Discount.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.DiscountCases.Handlers.QueryHandlers
{
    public class GetAllDiscountQueryHandler : IRequestHandler<GetAllDiscountQuery, List<DiscountModel>>
    {
            private readonly IDiscountDbContext _context;

        public GetAllDiscountQueryHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<List<DiscountModel>> Handle(GetAllDiscountQuery request, CancellationToken cancellationToken)
        {
            var discount = await _context.Discounts.ToListAsync();
            return discount;
        }
    }
}
