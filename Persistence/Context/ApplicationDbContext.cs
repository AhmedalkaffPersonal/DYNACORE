using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<ContactPerson> ContactPersons { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }


    }
}
