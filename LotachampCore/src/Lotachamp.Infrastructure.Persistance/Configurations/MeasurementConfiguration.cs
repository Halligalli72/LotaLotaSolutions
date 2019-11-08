using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lotachamp.Infrastructure.Persistance.Configurations
{
    public class MeasurementConfiguration : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("Measurement");
            builder.Property(p => p.MeasurementId).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ResultUnit).IsRequired().HasMaxLength(10);
            builder.Property(p => p.ResultFormatString).IsRequired().HasMaxLength(10);
            builder.Property(p => p.ResultLabelText).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Created).IsRequired().HasDefaultValueSql("(GETDATE())");
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Updated);
            builder.Property(p => p.UpdatedBy).HasMaxLength(50);
        }
    }
}
