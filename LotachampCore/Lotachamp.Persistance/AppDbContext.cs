using Lotachamp.Model.Entities;
using Lotachamp.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lotachamp.Persistance
{
    public class AppDbContext : DbContext //IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<RankAlgorithm> RankAlgorithms { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<Sport> SportEvents { get; set; }

        public DbSet<SportTemplate> SportEventTemplates { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<Invite> Invites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InviteConfiguration());
            modelBuilder.ApplyConfiguration(new MeasurementConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            modelBuilder.ApplyConfiguration(new RankAlgorithmConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new SportConfiguration());
            modelBuilder.ApplyConfiguration(new SportTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
        }

    }
}
