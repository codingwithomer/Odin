using Microsoft.EntityFrameworkCore;
using Odin.Common.Constants;
using Odin.Data.Models;
using Odin.DataAccess.Extensions;
using Odin.DataAccess.Mappings;

namespace Odin.DataAccess.Context
{
    public class OdinDbContext : DbContext
    {
        public OdinDbContext()
        {

        }

        public OdinDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConnectionInfo.ConnectionString, builder => builder.EnableRetryOnFailure());

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
