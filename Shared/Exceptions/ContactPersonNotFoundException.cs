using System;

namespace Domain.Exceptions
{
    public sealed class ContactPersonNotFoundException : NotFoundException
    {
        public ContactPersonNotFoundException(Guid productId)
        : base($"The contact person with the identifier {productId} was not found.")
        {
        }
    }
}
