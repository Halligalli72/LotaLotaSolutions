using Lotachamp.Model;
using Lotachamp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Persistance.Configurations
{
    public class RankAlgorithmConfiguration : IEntityTypeConfiguration<RankAlgorithm>
    {
        public void Configure(EntityTypeBuilder<RankAlgorithm> builder)
        {
            builder.ToTable("RankAlgorithm");
            builder.Property(p => p.RankAlgorithmId).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Created).IsRequired().HasDefaultValueSql("(GETDATE())");
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Updated);
            builder.Property(p => p.UpdatedBy).HasMaxLength(50);
        }
    }
}
