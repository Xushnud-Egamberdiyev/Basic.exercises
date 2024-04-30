using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handles.QueryHandlers
{
    public class GetAllCatalogsQueryHandler : IRequestHandler<GetAllCatalogsQuery, List<ProductCatalog>>
    {
        private readonly ICatalogDbContext _context;
        public GetAllCatalogsQueryHandler(ICatalogDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductCatalog>> Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
        {
            var catalogs = await _context.Catalogs.ToListAsync();
            return catalogs;
        }
    }
}
