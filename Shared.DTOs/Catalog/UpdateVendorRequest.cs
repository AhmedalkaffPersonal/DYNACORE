using System;

namespace Shared.DTOs.Catalog
{
    public class UpdateVendorRequest : IMustBeValid
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ContactPersonId { get; set; }
    }
}
