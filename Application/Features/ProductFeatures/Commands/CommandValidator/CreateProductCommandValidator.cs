using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CommandValidator
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SKU)
                .NotEmpty().WithMessage("SKU is required.")
                .MaximumLength(100).WithMessage("SKU must not exceed 100 characters.")
                .MustAsync(BeUniqueSKU).WithMessage("The specified SKU already exists.");
        }

        public async Task<bool> BeUniqueSKU(string sku, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AllAsync(l => l.SKU != sku, cancellationToken);
        }
    }
}
