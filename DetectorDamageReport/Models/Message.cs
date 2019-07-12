using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Message
    {
        public Message()
        {
            Train = new HashSet<Train>();
        }

        public long MessageId { get; set; }
        public string Vendor { get; set; }
        public string SoftwareVersion { get; set; }
        public DateTime SendTimeStamp { get; set; }
        public string LocationId { get; set; }
        public string CountryCode { get; set; }
        public string Owner { get; set; }
        public string Track { get; set; }

        public virtual ICollection<Train> Train { get; set; }
    }
}
