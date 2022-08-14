using Application.Interfaces;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VendorFeatures.Commands
{
    public class DeleteVendorByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public class DeleteVendorByIdCommandHandler : IRequestHandler<DeleteVendorByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteVendorByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteVendorByIdCommand command, CancellationToken cancellationToken)
            {
                var vendor = await _context.Vendors.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (vendor == null)
                {
                    throw new VendorNotFoundException(command.Id);
                }
                _context.Vendors.Remove(vendor);
                await _context.SaveChangesAsync();
                return vendor.Id;
            }


        }
    }
}
