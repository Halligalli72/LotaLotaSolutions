using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class RankAlgorithm
    {
        public int RankAlgorithmId { get; set; }
        public string Name { get; set; }
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }


        public RankAlgorithm()
        {
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }
    }
}
