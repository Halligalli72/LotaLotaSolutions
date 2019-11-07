using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Application.BusinessObjects
{
    public class ScoreBO : Score
    {
        public int? Rank { get; set; }
        public int Points { get; set; }

        private ScoreBO() { }

        public ScoreBO(Score s) 
        {
            this.ScoreId = s.ScoreId;
            this.SportId = s.SportId;
            this.Sport = s.Sport;
            this.ParticipantId = s.ParticipantId;
            this.Participant = s.Participant;
            this.ResultValue = s.ResultValue;
            this.ScoreDate = s.ScoreDate;
            this.Notes = s.Notes;
            this.Pictures = s.Pictures;
            this.Points = 0;
        }
    }
}
