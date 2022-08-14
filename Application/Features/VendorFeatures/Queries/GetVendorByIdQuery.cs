using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VendorFeatures.Queries
{
    public class GetVendorByIdQuery : IRequest<Vendor>
    {
        public Guid Id { get; set; }
        public class GetvendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, Vendor>
        {
            private readonly IApplicationDbContext _context;
            public GetvendorByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Vendor?> Handle(GetVendorByIdQuery query, CancellationToken cancellationToken)
            {
                var vendor = _context.Vendors.Where(a => a.Id == query.Id).FirstOrDefault();
                if (vendor == null)
                {
                    throw new VendorNotFoundException(query.Id);
                }
                return vendor;
            }
        }
    }
}
