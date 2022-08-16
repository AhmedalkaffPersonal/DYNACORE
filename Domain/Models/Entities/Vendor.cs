using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("Vendors")]
    public class Vendor : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(500)]
        public string? Address { get; set; }

        [Required]
        public string? TaxNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        public Guid? ContactPersonId { get; set; }
        public virtual ContactPerson? ContactPerson { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
