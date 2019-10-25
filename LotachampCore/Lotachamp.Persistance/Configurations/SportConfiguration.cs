using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lotachamp.Persistance.Configurations
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.ToTable("SportEvent");
            builder.Property(p => p.SportId).IsRequired().UseIdentityColumn();
            builder.Property(p => p.TourId).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
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

            //Relationships
            builder.HasOne(se => se.Measurement);
            builder.HasOne(se => se.RankAlgorithm);
            builder.HasOne(se => se.Tour)
                .WithMany(t => t.Sports)
                .HasForeignKey(se => se.TourId);
            builder.HasMany(p => p.Scores)
                .WithOne(s => s.Sport)
                .HasForeignKey(p => p.SportId);

        }
    }
}
