using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Model.Entities
{
    public class Picture : BaseEntity
    {
        public Picture()
        {
            Created = DateTime.Now;
        }

        public int PictureId { get; set; }
        public Guid ScoreId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string ImageText { get; set; }

        /// <summary>
        /// (ImagePath) To be used when moving to azure blob storage
        /// </summary>
        public string ImagePath { get; set; }

        public virtual Score Score { get; set; }

    }
}
