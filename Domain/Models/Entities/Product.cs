using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? SKU { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public double Quantity { get; set; }

        public Guid VendorId { get; set; }
        public virtual Vendor? Vendor { get; set; }
    }
}
