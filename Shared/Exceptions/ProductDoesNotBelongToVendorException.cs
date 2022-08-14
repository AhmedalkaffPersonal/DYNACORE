using System;

namespace Domain.Exceptions
{
    public sealed class ProductDoesNotBelongToVendorException : BadRequestException
    {
        public ProductDoesNotBelongToVendorException(int vendorId, Guid productId)
        : base($"The product with the identifier {productId} does not belong to the vendor with the identifier {vendorId}")
        {
        }
    }
}
