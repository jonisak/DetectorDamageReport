using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Traindirection
    {
        public Traindirection()
        {
            Train = new HashSet<Train>();
        }

        public int TrainDirectionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Train> Train { get; set; }
    }
}
