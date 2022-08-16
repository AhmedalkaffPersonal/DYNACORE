using Shared.DTOs.Filters;
using System;

namespace Shared.DTOs.Catalog
{
    public class ProductListFilter : PaginationFilter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public VendorDto Vendor { get; set; }
    }
}
