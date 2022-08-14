using Application.Interfaces;
using Domain.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VendorFeatures.Commands
{
    public class UpdateVendorCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? TaxNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid ContactPersonId { get; set; }
        public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public UpdateVendorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(UpdateVendorCommand command, CancellationToken cancellationToken)
            {
                var vendor = _context.Vendors.Where(a => a.Id == command.Id).FirstOrDefault();

                if (vendor == null)
                {
                    throw new VendorNotFoundException(command.Id);
                }
                else
                {
                    vendor.Name = command.Name;
                    vendor.Address = command.Address;
                    vendor.TaxNumber = command.TaxNumber;
                    vendor.PhoneNumber = command.PhoneNumber;
                    vendor.ContactPersonId = command.ContactPersonId;
                    await _context.SaveChangesAsync();
                    return vendor.Id;
                }
            }
        }
    }
}
