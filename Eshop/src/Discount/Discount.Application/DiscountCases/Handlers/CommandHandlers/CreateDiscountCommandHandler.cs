using Discount.Application.Abstractions;
using Discount.Application.DiscountCases.Commands;
using Discount.Domain.Entities;
using Discount.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.DiscountCases.Handlers.CommandHandlers
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, ResponseModel>
    {
        private readonly IDiscountDbContext _context;

        public CreateDiscountCommandHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            if(request != null)
            {
                var discount = new DiscountModel
                {
                    ProductId = request.ProductId,
                    CuponCode = request.CuponCode,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate

                };
                await _context.Discounts.AddAsync(discount);
                await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    Message = $"Cupon with code {request.CuponCode} created",
                    StatusCode = 201,
                    IsSuccessed = true,
                };
            }
            else
            {
                return new ResponseModel
                {
                    Message = $"Request might be null",
                    StatusCode = 400,
                    
                };
            }
        }
    }
}
