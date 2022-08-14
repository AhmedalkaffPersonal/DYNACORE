using System;

namespace Domain.Exceptions
{
    public sealed class VendorNotFoundException : NotFoundException
    {
        public VendorNotFoundException(Guid vendorId)
        : base($"The vendor with the identifier {vendorId} was not found.")
        {
        }
    }
}
