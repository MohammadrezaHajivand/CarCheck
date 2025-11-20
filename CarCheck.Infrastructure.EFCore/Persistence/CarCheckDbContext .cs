using CarCheck.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarCheck.Infrastructure.EFCore.Persistence
{
    public class CarCheckDbContext : DbContext
    {
        public CarCheckDbContext(DbContextOptions<CarCheckDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<InspectionRequest> InspectionRequests { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarCheckDbContext).Assembly);
        }
    }
}
