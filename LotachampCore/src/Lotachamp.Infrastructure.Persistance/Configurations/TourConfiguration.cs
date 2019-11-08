using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lotachamp.Infrastructure.Persistance.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.ToTable("Tour");
            builder.Property(p => p.TourId).IsRequired().UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(p => p.IsPublic).IsRequired();
            builder.Property(p => p.Created).IsRequired().HasDefaultValueSql("(GETDATE())");
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Updated);
            builder.Property(p => p.UpdatedBy).HasMaxLength(50);

            //Relationships
            builder.HasMany(t => t.Participants)
                .WithOne(p => p.Tour)
                .HasForeignKey(t => t.TourId);
            builder.HasMany(t => t.Sports)
                .WithOne(se => se.Tour)
                .HasForeignKey(t => t.TourId);
        }
    }
}
