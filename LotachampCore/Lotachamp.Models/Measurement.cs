using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class Measurement
    {
        public int MeasurementId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Ex g, cm, sek, p
        /// </summary>
        public string ResultUnit { get; set; }

        /// <summary>
        /// Format string
        /// </summary>
        public string ResultFormatString { get; set; }

        /// <summary>
        /// Example: Vikt, Längd, Tid, Poäng, Antal slag
        /// </summary>
        public string ResultLabelText { get; set; }

        public System.DateTime Updated { get; set; }

        public string UpdatedBy { get; set; }

        public System.DateTime Created { get; set; }

        public string CreatedBy { get; set; }


        public Measurement()
        {
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }
    }
}
