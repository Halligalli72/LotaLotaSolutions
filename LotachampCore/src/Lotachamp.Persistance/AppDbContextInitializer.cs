using Lotachamp.Domain;
using Lotachamp.Domain.Entities;
using Lotachamp.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotachamp.Persistance
{
    public class AppDbContextInitializer
    {
        private readonly Dictionary<int, Invite> LotathlonUsers = new Dictionary<int, Invite>();
        private readonly Dictionary<int, Measurement> Measurements = new Dictionary<int, Measurement>();
        private readonly Dictionary<int, Participant> Participants = new Dictionary<int, Participant>();
        private readonly Dictionary<int, Picture> Pictures = new Dictionary<int, Picture>();
        private readonly Dictionary<int, RankAlgorithm> RankAlgorithms = new Dictionary<int, RankAlgorithm>();
        private readonly Dictionary<int, Score> Scores = new Dictionary<int, Score>();
        private readonly Dictionary<int, Sport> Sports = new Dictionary<int, Sport>();
        private readonly Dictionary<int, SportTemplate> SportTemplates = new Dictionary<int, SportTemplate>();
        private readonly Dictionary<int, Tour> Tours = new Dictionary<int, Tour>();

        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppDbContextInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(AppDbContext context)
        {
            context.Database.EnsureCreated();

            //Metadata
            SeedRankAlgorithms(context);
            SeedMeasurements(context);

            //Tour data
            SeedMemberTour(context);
        }


        public void SeedRankAlgorithms(AppDbContext ctx)
        {
            if (!ctx.RankAlgorithms.Any())
            {
                var algorithms = new[] {
                    new RankAlgorithm { RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, Name = "Mest/högst/längst vinner", CreatedBy = "setup" },
                    new RankAlgorithm { RankAlgorithmId = (int)RankAlgorithmEnum.LowestWins, Name = "Minst/snabbast vinner", CreatedBy = "setup" }
                };
                ctx.RankAlgorithms.AddRange(algorithms);
                ctx.SaveChanges();
            }
        }

        public void SeedMeasurements(AppDbContext ctx)
        {
            if (!ctx.Measurements.Any())
            {
                var measurements = new[] {
                    new Measurement { MeasurementId = (int)MeasurementEnum.Grams, Name = "gram", ResultUnit = "g", ResultFormatString = string.Empty, ResultLabelText = "Vikt", CreatedBy="setup"},
                    new Measurement { MeasurementId = (int)MeasurementEnum.Centimeters, Name = "centimeter", ResultUnit = "cm", ResultFormatString = string.Empty, ResultLabelText = "Längd", CreatedBy="setup"},
                    new Measurement { MeasurementId = (int)MeasurementEnum.Seconds, Name = "sekunder", ResultUnit = "sek", ResultFormatString = string.Empty, ResultLabelText = "Tid", CreatedBy="setup"},
                    new Measurement { MeasurementId = (int)MeasurementEnum.Points, Name = "poäng", ResultUnit = "p", ResultFormatString = string.Empty, ResultLabelText = "Poäng", CreatedBy="setup"},
                    new Measurement { MeasurementId = (int)MeasurementEnum.Hits, Name = "slag", ResultUnit = "slag", ResultFormatString = string.Empty, ResultLabelText = "Antal slag", CreatedBy="setup"},
                    new Measurement { MeasurementId = (int)MeasurementEnum.Tries, Name = "försök", ResultUnit = "försök", ResultFormatString = string.Empty, ResultLabelText = "Antal försök", CreatedBy="setup"},
                };
                ctx.Measurements.AddRange(measurements);
                ctx.SaveChanges();
            }
        }

        private void SeedMemberTour(AppDbContext ctx)
        {
            if (ctx.Tours.Any())
                return;

            //Invites
            var invites = new[]
            {
                    new Invite { InviteId=Constants.MemberInvites.MattiasFalt, Name="Mattias Fält", Email="mattias.falt@lotalota.se", Activated=true, InvitedBy=Constants.System.SysAdminId, CanInvite = true, InviteLimit=1000, CreatedBy="setup" },

                    new Invite { InviteId=Constants.MemberInvites.AndersCeder, Name="Anders Ceder", Email="anders.ceder@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.EricPersson, Name="Eric Persson",Email="eric.persson@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.FredrikFalt, Name="Fredrik Fält",Email="fredrik.falt@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.JanAndersson, Name="Jan Andersson",Email="jan.andersson@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.JaniKorpela, Name="Jani Korpela",Email="jani.korpela@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.JohanHallberg, Name="Johan Hallberg",Email="johan.hallberg@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.JohanHenriksson, Name="Johan Henriksson",Email="johan.henriksson@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.JohnnyHenriksson, Name="Johnny Henriksson",Email="johnny.henriksson@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.JorgenWiklund, Name="Jörgen Wiklund",Email="jorgen.wiklund@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.PerNorberg, Name="Per Norberg",Email="per.norberg@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.PetterFalt, Name="Petter Fält",Email="petter.falt@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.ParOstlund, Name="Pär Östlund",Email="par.ostlund@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                    new Invite { InviteId=Constants.MemberInvites.TapioMurto, Name="Tapio Murto",Email="tapio.murto@lotalota.se", Activated=true, InvitedBy=Constants.MemberInvites.MattiasFalt, CreatedBy="setup" },
                };
            ctx.Invites.AddRange(invites);
            ctx.SaveChanges();

            //Tour
            var tour = new Tour { Name = "Lotachamp 2019", Description = "Lota lotas turnering", StartDate = DateTime.Parse("2019-04-01"), EndDate = DateTime.Parse("2019-12-31"), CreatedBy = "setup" };
            ctx.Tours.Add(tour);

            //SportEvents
            var sportevents = new[] {
                new Sport { Name = "Abborre", RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, MeasurementId = (int)MeasurementEnum.Grams, PictureRequired=true, P1=25,P2=20,P3=17,P4=15,P5=14,SeedPoint=1, CreatedBy="setup" },
                new Sport { Name = "Gädda", RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, MeasurementId = (int)MeasurementEnum.Grams, PictureRequired=true, P1=25,P2=20,P3=17,P4=15,P5=14,SeedPoint=1, CreatedBy="setup" },
                new Sport { Name = "Harr", RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, MeasurementId = (int)MeasurementEnum.Grams, PictureRequired=true, P1=25,P2=20,P3=17,P4=15,P5=14,SeedPoint=1, CreatedBy="setup" },
                new Sport { Name = "Lake", RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, MeasurementId = (int)MeasurementEnum.Grams, PictureRequired=true, P1=50,P2=40,P3=34,P4=30,P5=28,SeedPoint=2, CreatedBy="setup" },
                new Sport { Name = "Lax", RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, MeasurementId = (int)MeasurementEnum.Grams, PictureRequired=true, P1=25,P2=20,P3=17,P4=15,P5=14,SeedPoint=1, CreatedBy="setup" },
                new Sport { Name = "Sik", RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, MeasurementId = (int)MeasurementEnum.Grams, PictureRequired=true, P1=25,P2=20,P3=17,P4=15,P5=14,SeedPoint=1, CreatedBy="setup" },
                new Sport { Name = "Öring", RankAlgorithmId = (int)RankAlgorithmEnum.HighestWins, MeasurementId = (int)MeasurementEnum.Grams, PictureRequired=true, P1=25,P2=20,P3=17,P4=15,P5=14,SeedPoint=1, CreatedBy="setup" },
             };
            foreach (var se in sportevents)
                tour.Sports.Add(se);
            ctx.SaveChanges();

            //Participants
            var participants = new[] {
                new Participant { Invite = invites[0], Name = invites[0].Name, Alias="Mattias", IsCompeting = true, IsTourAdmin = true, IsTourOfficial = true, CreatedBy="setup" },
                new Participant { Invite = invites[1], Name = invites[1].Name, Alias="Anders", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[2], Name = invites[2].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[3], Name = invites[3].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[4], Name = invites[4].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[5], Name = invites[5].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[6], Name = invites[6].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[7], Name = invites[7].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[8], Name = invites[8].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[9], Name = invites[9].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[10], Name = invites[10].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[11], Name = invites[11].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[12], Name = invites[12].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
                new Participant { Invite = invites[13], Name = invites[13].Name, Alias="", IsCompeting = true, CreatedBy="setup" },
            };
            foreach (var p in participants)
                tour.Participants.Add(p);
            ctx.SaveChanges();
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

    }
}
