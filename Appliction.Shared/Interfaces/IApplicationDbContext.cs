using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Vendor> Vendors { get; set; }
        DbSet<ContactPerson> ContactPersons { get; set; }
        Task<int> SaveChanges();
        Task SaveChangesAsync();
    }
}
