using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Model.Entities
{
    public class SportTemplate : BaseEntity
    {
        public SportTemplate()
        {
            Created = DateTime.Now;
        }

        public int SportTemplateId { get; set; }
        public string TemplateName { get; set; }
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
    }
}
