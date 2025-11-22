using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarCheck.Domain.Core.Entities;

namespace CarCheck.Infrastructure.EFCore.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                   .IsRequired(false)
                   .HasMaxLength(50);
            builder.Property(u => u.Password)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(u => u.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.NationalCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasIndex(u => u.NationalCode)
                   .IsUnique();

            builder.HasMany(u => u.vehicles)
                .WithOne(v => v.Owener)
                .HasForeignKey(v => v.OwnerId);

            builder.HasMany(u => u.inspectionRequests)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId);

        }
    }
}