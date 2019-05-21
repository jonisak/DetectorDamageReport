using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Traindirection
    {
        public Traindirection()
        {
            Message = new HashSet<Message>();
        }

        public int TrainDirectionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
