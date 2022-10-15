
using Domain.Buildings;
using Infra.Data.Buildings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BuildingMap());
        }
    }
}