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

            builder.Property(v => v.OwnerId)
                .IsRequired();

            builder.HasOne(v => v.Owener)
                .WithMany(u => u.vehicles)
                .HasForeignKey(v => v.OwnerId);


        }
    }
}