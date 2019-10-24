using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Model.Entities
{
    public class Measurement : BaseEntity
    {
        public Measurement()
        {
            Created = DateTime.Now;
        }

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
    }
}
