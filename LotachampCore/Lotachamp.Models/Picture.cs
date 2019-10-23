using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class Picture
    {
        public int PictureId { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public Picture()
        {
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }
    }
}
