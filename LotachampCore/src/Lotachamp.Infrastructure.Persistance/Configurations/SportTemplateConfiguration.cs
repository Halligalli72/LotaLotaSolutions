using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lotachamp.Infrastructure.Persistance.Configurations
{
    public class SportTemplateConfiguration : IEntityTypeConfiguration<SportTemplate>
    {
        public void Configure(EntityTypeBuilder<SportTemplate> builder)
        {
            builder.ToTable("SportTemplate");
            builder.Property(p => p.SportTemplateId).IsRequired().UseIdentityColumn();
            builder.Property(p => p.RankAlgorithmId).IsRequired();
            builder.Property(p => p.MeasurementId).IsRequired();
            builder.Property(p => p.PictureRequired).IsRequired();
            builder.Property(p => p.P1).IsRequired();
            builder.Property(p => p.P2).IsRequired();
            builder.Property(p => p.P3).IsRequired();
            builder.Property(p => p.P4).IsRequired();
            builder.Property(p => p.P5).IsRequired();
            builder.Property(p => p.SeedPoint).IsRequired();
            builder.Property(p => p.Created).IsRequired().HasDefaultValueSql("(GETDATE())");
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Updated);
            builder.Property(p => p.UpdatedBy).HasMaxLength(50);
        }
    }
}
