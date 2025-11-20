using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarCheck.Domain.Core.Entities;

namespace CarCheck.Infrastructure.EFCore.Configs
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.PlateNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(v => v.PlateNumber)
                   .IsUnique();

            builder.Property(v => v.YearOfManufacture)
                   .IsRequired();

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(v => v.OwnerId);

            builder.HasOne<VehicleModel>()
                   .WithMany()
                   .HasForeignKey(v => v.ModelId);
        }
    }
}