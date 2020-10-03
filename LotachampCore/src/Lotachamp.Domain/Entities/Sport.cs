using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Domain.Entities
{
    public class Sport : BaseEntity
    {
        public Sport()
        {
            Scores = new HashSet<Score>();
            Created = DateTime.Now;
        }

        public int SportId { get; set; }
        public int TourId { get; set; }
        public string Name { get; set; }
        public int RankAlgorithmId { get; set; }
        public int MeasurementId { get; set; }
        public bool PictureRequired { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int P5 { get; set; }
        public int SeedPoint { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual RankAlgorithm RankAlgorithm { get; set; }
        public virtual ICollection<Score> Scores { get; private set; }
        public virtual Tournament Tour { get; set; }
    }
}
