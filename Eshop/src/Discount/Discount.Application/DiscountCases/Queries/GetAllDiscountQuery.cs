using Discount.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.DiscountCases.Queries
{
    public class GetAllDiscountQuery : IRequest<List<DiscountModel>>
    {
    }
}
