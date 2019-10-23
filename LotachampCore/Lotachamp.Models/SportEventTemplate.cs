using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class SportEventTemplate
    {
        public int SportEventTemplateId { get; set; }
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
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual RankAlgorithm RankAlgorithm { get; set; }


        public SportEventTemplate()
        {
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }
    }
}
