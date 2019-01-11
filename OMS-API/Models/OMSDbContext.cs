using Microsoft.EntityFrameworkCore;
using OMSAPI.Models;

namespace OMSAPI.DataContext
{
    public class OMSDbContext : DbContext
    {
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
        public OMSDbContext(DbContextOptions contextOptions) : base(contextOptions) {}
    }
}