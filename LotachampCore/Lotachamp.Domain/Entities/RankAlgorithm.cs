using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Domain.Entities
{
    public class RankAlgorithm : BaseEntity
    {
        public RankAlgorithm()
        {
            Created = DateTime.Now;
        }

        public int RankAlgorithmId { get; set; }
        public string Name { get; set; }
    }
}
