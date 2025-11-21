using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarCheck.Domain.Core.Entities;

namespace CarCheck.Infrastructure.EFCore.Configs
{
    public class InspectionRequestConfig : IEntityTypeConfiguration<InspectionRequest>
    {
        public void Configure(EntityTypeBuilder<InspectionRequest> builder)
        {
            builder.ToTable("InspectionRequests");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.CompanyName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.RequestedDate)
                   .IsRequired();

            builder.Property(r => r.CreatedAt)
                   .IsRequired();

            builder.Property(r => r.Status)
                   .IsRequired();

            builder.HasOne(r => r.User)
                   .WithMany()
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Vehicle)
                   .WithMany()
                   .HasForeignKey(r => r.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }


    }
}