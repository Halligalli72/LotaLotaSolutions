using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class Score 
    {
        //private members
        private int _ranking = 0;
        private int _obtainedPoints = 0;

        public int ScoreId { get; set; }
        public int TourId { get; set; }
        public int SportEventId { get; set; }
        public int ParticipantId { get; set; }
        public int ResultValue { get; set; }
        public System.DateTime ScoreDate { get; set; }
        public int? PictureId { get; set; }

        /// <summary>
        /// (ImagePath) To be used when moving to azure blob storage
        /// </summary>
        public string ImagePath { get; set; }
        public string Notes { get; set; }
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public Score()
        {
            ScoreDate = DateTime.Now;
            PictureId = null;
            ImagePath = "";
            Notes = "";
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }

        public virtual Participant Participant { get; set; }

        public virtual SportEvent SportEvent { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual Picture Picture { get; set; }

        public void SetRank(int ranking)
        {
            this._ranking = ranking;
        }

        public int GetRank()
        {
            return this._ranking;
        }

        public void SetPoints(int points)
        {
            this._obtainedPoints = points;
        }

        public int GetPoints()
        {
            return this._obtainedPoints;
        }


        /// <summary>
        /// This method contains the ranking algorithm
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        //public int CompareTo(Score other)
        //{
        //    if (this.SportEvent.RankAlgorithmId == 1)
        //    {
        //        // Högst PrimaryResult vinner, om lika så vinner den senaste 
        //        if (other.ResultValue.Equals(this.ResultValue))
        //            return other.ScoreDate.CompareTo(this.ScoreDate);
        //        else
        //            return other.ResultValue.CompareTo(this.ResultValue);
        //    }
        //    else if (this.SportEvent.RankAlgorithmId == 2)
        //    {
        //        // Lägst PrimaryResult vinner, om lika så vinner den senaste 
        //        if (other.ResultValue.Equals(this.ResultValue))
        //            return other.ScoreDate.CompareTo(this.ScoreDate);
        //        else
        //            return this.ResultValue.CompareTo(other.ResultValue);
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid rank algorithm when comparing (id:" + this.SportEvent.RankAlgorithmId + ")");
        //    }
        //}
    }
}
