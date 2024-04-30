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
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _context; 
        public DeleteCatalogCommandHandler(ICatalogDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
           var catalog = await _context.Catalogs.FirstOrDefaultAsync(x=> x.Id==request.CatalogId);
           if(catalog != null)
            {
                _context.Catalogs.Remove(catalog!);
                await _context.SaveChangesAsync(cancellationToken);
                return new ResponseModel()
                {
                    StatusCode = 200,
                    Message = $"{catalog.Name} deleted",
                    IsSuccess = true
                };
            }
            else
            {
                return new ResponseModel()
                {
                    StatusCode = 400,
                    Message = $"CatalogId might be null or not found"
                };
            }
        }
    }
}
