﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class TrainFilterDTO
    {
        public int MaxResultCount { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public bool ShowTrainWithAlarmOnly { get; set; }

        public List<DeviceTypeDTO> DeviceTypeDTOList { get; set; }
    }
}

