using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Lotachamp.Model
{
    public static class Constants
    {
        public static class System
        {
            public static Guid SysAdminId = Guid.Parse("84084001-4DC3-4BA5-962D-8ACE8A5E24FA");
        }
      
        public static class MemberInvites
        {
            public static Guid AndersCeder = Guid.Parse("111EC3CD-0605-4ED6-8CBE-CA1186D88407");
            public static Guid EricPersson = Guid.Parse("A166DF69-B989-4C53-8703-A42632E987D6");
            public static Guid FredrikFalt = Guid.Parse("9C8827B6-6AE2-4471-AE3C-358816F92E8D");
            public static Guid JanAndersson = Guid.Parse("E67F975F-293E-48C8-A3B8-BF8095CD1511");
            public static Guid JaniKorpela = Guid.Parse("3E4E3365-DE34-475D-9D4D-68066044FE9E");
            public static Guid JohanHallberg = Guid.Parse("97148CCB-DA6C-4785-8D06-7F47BBA73BA1");
            public static Guid JohanHenriksson = Guid.Parse("D0D2B3DA-FCEA-47FE-B96F-DF83341D7984");
            public static Guid JohnnyHenriksson = Guid.Parse("A8F4AC0B-8254-48AD-8AE6-62909053620B");
            public static Guid JorgenWiklund = Guid.Parse("CF606639-7058-4AF6-8FA3-9D4C1E835462");
            public static Guid MattiasFalt = Guid.Parse("7A94C63B-D050-4F60-B679-E4CDC34CED29");
            public static Guid PerNorberg = Guid.Parse("91C09689-4247-4EE9-9F79-7134403B29E2");
            public static Guid PetterFalt = Guid.Parse("F5CDF998-2D06-448B-A045-8C47B504A570");
            public static Guid ParOstlund = Guid.Parse("8638C585-E4B1-4036-B10E-CF212377444F");
            public static Guid TapioMurto = Guid.Parse("2A794C0F-4A2E-4928-B2A4-8E7A758C32EC");
        }

        public static class ClaimData
        {
            public const string SysAdmin = "SysAdmin";
            public const string ManageUsers = "ManageUsers";
            public const string ManageTours = "ManageTours";
            public const string ManageScores = "ManageScores";

            private static readonly Claim SysAdminClaim = new Claim(SysAdmin, "System Admin.");
            private static readonly Claim ManageUsersClaim = new Claim(ManageUsers, "Manage Users");
            private static readonly Claim ManageToursClaim = new Claim(ManageTours, "Manage Tours");
            private static readonly Claim ManageScoresClaim = new Claim(ManageScores, "Manage Scores");

            public static IList<Claim> AllClaims => new List<Claim> { SysAdminClaim, ManageUsersClaim, ManageToursClaim, ManageScoresClaim };
        }
    }
}
