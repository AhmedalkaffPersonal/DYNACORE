using Application.Interfaces;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VendorFeatures.Commands
{
    public class CreateVendorCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? TaxNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid ContactPersonId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateVendorCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateVendorCommand command, CancellationToken cancellationToken)
            {
                var vendor = new Vendor();
                vendor.Name = command.Name;
                vendor.Address = command.Address;
                vendor.TaxNumber = command.TaxNumber;
                vendor.PhoneNumber = command.PhoneNumber;
                vendor.ContactPersonId = command.ContactPersonId;
                _context.Vendors.Add(vendor);
                await _context.SaveChangesAsync();
                return vendor.Id;
            }


        }
    }
}
