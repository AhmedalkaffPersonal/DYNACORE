using Application.Interfaces;
using Domain.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SKU { get; set; }
        public string? Description { get; set; }
        public double Quantity { get; set; }
        public Guid VendorId { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();

                if (product == null)
                {
                    throw new ProductNotFoundException(command.Id);
                }
                else
                {
                    product.SKU = command.SKU;
                    product.Name = command.Name;
                    product.Quantity = command.Quantity;
                    product.Description = command.Description;
                    product.VendorId = command.VendorId;
                    await _context.SaveChangesAsync();
                    return product.Id;
                }
            }
        }
    }
}
