using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class SportEvent
    {
        public int SportEventId { get; set; }
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
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual RankAlgorithm RankAlgorithm { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual Tour Tour { get; set; }

        public SportEvent()
        {
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }

        public int CalculateObtainedPoints(int position)
        {
            switch (position)
            {
                case 0:
                    return 0;
                case 1:
                    return this.P1;
                case 2:
                    return this.P2;
                case 3:
                    return this.P3;
                case 4:
                    return this.P4;
                case 5:
                    return this.P5;
                default:
                    int score = this.P5 - ((position-5) * this.SeedPoint);
                    if (score > 0)
                        return score;
                    else
                        return 0; 
            }
        }


    }
}
