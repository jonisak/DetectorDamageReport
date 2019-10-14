using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class DetectorDTO
    {
        public int DetectorId { get; set; }
        public string SGLN { get; set; }
        public string Name { get; set; }
        public string DetectorType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
