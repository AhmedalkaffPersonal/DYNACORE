using Application.Interfaces;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? SKU { get; set; }
        public string? Description { get; set; }
        public double Quantity { get; set; }
        public Guid VendorId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.SKU = command.SKU;
                product.Name = command.Name;
                product.Quantity = command.Quantity;
                product.Description = command.Description;
                product.VendorId = command.VendorId;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }


        }
    }
}
