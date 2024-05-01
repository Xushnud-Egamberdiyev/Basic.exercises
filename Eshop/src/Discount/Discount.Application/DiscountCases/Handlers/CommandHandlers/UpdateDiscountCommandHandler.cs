using Discount.Application.Abstractions;
using Discount.Application.DiscountCases.Commands;
using Discount.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.DiscountCases.Handlers.CommandHandlers
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, ResponseModel>
    {
        private readonly IDiscountDbContext _context;

        public UpdateDiscountCommandHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(x=>x.Id == request.DiscountId);
            if (discount != null)
            {
                discount.ProductId = request.ProductId;
                discount.StartDate = request.StartDate;
                discount.EndDate = request.EndDate;
                discount.CuponCode = request.CuponCode;
                await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    Message = $"Discount with Id {discount.Id} updated",
                    StatusCode = 200,
                    IsSuccessed = true

                };
            }
            else
            {
                return new ResponseModel
                {
                    Message = $"Discount with Id is null or not found",
                    StatusCode = 400,
                    

                };
            }
        }
    }
}
