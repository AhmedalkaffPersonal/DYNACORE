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

    //public static class ApplicationDbContextExtentions
    //{
    //    public static IQueryable<Vendor> VendorWithProducts(this ApplicationDbContext dbContext, Guid vendorId)
    //    {
    //        return dbContext.Vendors.Where(vendor => vendor.Id == vendorId)
    //            .Include(vendor => vendor.Products)
    //            .Include(vendor => vendor.ContactPerson)
    //            .AsQueryable();
    //    }

    //}
}
