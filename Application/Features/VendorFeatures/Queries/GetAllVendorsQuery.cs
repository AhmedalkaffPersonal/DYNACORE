using Application.Interfaces;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VendorFeatures.Queries
{
    public class GetAllVendorsQuery : IRequest<IEnumerable<Vendor>>
    {
        public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, IEnumerable<Vendor>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllVendorsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Vendor>?> Handle(GetAllVendorsQuery query, CancellationToken cancellationToken)
            {
                var vendorList = await _context.Vendors.ToListAsync();
                if (vendorList == null)
                {
                    return null;
                }
                return vendorList.AsReadOnly();
            }
        }
    }
}
