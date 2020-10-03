using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lotachamp.Application.Infrastructure
{
    public interface ILotachampContext
    {
        DbSet<Invite> Invites { get; set; }
        DbSet<Measurement> Measurements { get; set; }
        DbSet<Participant> Participants { get; set; }
        DbSet<Picture> Pictures { get; set; }
        DbSet<RankAlgorithm> RankAlgorithms { get; set; }
        DbSet<Score> Scores{ get; set; }
        DbSet<Sport> Sports { get; set; }
        DbSet<SportTemplate> SportTemplates { get; set; }
        DbSet<Tournament> Tours { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
