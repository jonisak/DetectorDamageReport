using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class PagingDTO
    {
        public int MaxResultCount { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
