using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("ContactPersons")]
    public class ContactPerson : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
