using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Model.Entities
{
    public abstract class BaseEntity
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

    }
}
