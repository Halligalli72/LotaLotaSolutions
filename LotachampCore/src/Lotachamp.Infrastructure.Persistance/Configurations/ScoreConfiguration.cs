using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lotachamp.Infrastructure.Persistance.Configurations
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Score").HasKey(s => s.ScoreId);
            builder.Property(p => p.ScoreId).IsRequired().HasDefaultValueSql("(NEWID())");
            builder.Property(p => p.ParticipantId).IsRequired();
            builder.Property(p => p.ResultValue).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.ScoreDate).IsRequired().HasColumnType("Date");
            builder.Property(p => p.Notes).HasMaxLength(255);
            builder.Property(p => p.Updated);
            builder.Property(p => p.UpdatedBy).HasMaxLength(50);
            builder.Property(p => p.Created).IsRequired().HasDefaultValueSql("(GETDATE())");
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(50);

            //Relationships
            builder.HasOne(s => s.Sport)
                .WithMany(se => se.Scores)
                .HasForeignKey(s => s.SportId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Participant)
                .WithMany(p => p.Scores)
                .HasForeignKey(s => s.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Pictures)
                .WithOne(p => p.Score)
                .HasForeignKey(s => s.ScoreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
