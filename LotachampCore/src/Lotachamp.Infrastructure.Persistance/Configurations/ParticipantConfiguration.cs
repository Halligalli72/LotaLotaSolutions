using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lotachamp.Infrastructure.Persistance.Configurations
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participant");
            builder.Property(p => p.ParticipantId).IsRequired().HasDefaultValueSql("(NEWID())");
            builder.Property(p => p.TourId).IsRequired();
            builder.Property(p => p.InviteId).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Alias).IsRequired().HasMaxLength(10);
            builder.Property(p => p.IsTourAdmin).IsRequired();
            builder.Property(p => p.IsCompeting).IsRequired();
            builder.Property(p => p.IsTourOfficial).IsRequired();
            builder.Property(p => p.Created).IsRequired().HasDefaultValueSql("(GETDATE())");
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Updated);
            builder.Property(p => p.UpdatedBy).HasMaxLength(50);

            //Relationships
            builder.HasOne(p => p.Invite);
            builder.HasOne(p => p.Tour)
                .WithMany(t => t.Participants)
                .HasForeignKey(p => p.TourId);
            builder.HasMany(p => p.Scores)
                .WithOne(s => s.Participant)
                .HasForeignKey(p => p.ParticipantId);
        }
    }
}
