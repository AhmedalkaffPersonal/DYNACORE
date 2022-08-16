using System;
using System.Collections.Generic;

namespace Shared.DTOs.Catalog
{
    public class VendorDetailsDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public ContactPersonDto ContactPerson { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
