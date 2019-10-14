using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Detector
    {
        public Detector()
        {
            Message = new HashSet<Message>();
        }

        public int DetectorId { get; set; }
        public string Sgln { get; set; }
        public string Name { get; set; }
        public string DetectorType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
