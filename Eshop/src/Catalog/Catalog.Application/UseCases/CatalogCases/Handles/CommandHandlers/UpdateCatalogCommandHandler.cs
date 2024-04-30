using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handles.CommandHandlers
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _context;
        public UpdateCatalogCommandHandler(ICatalogDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(x=> x.Id == request.CatalogId);
            if(catalog != null) 
            { 
              catalog.Name=request.Name;
              catalog.Description=request.Description;
              await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    StatusCode = 200,
                    Message = $"Catalog with id {catalog.Id} updated",
                    IsSuccess = true
                };
            
            }
            else
            {
                return new ResponseModel
                {
                    StatusCode = 400,
                    Message = $"CatalogId null or not found"
                   
                };
            }
        }
    }
}
