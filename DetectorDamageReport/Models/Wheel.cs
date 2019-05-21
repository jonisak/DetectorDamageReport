using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Wheel
    {
        public Wheel()
        {
            HotBoxHotWheelMeasureWheelData = new HashSet<HotBoxHotWheelMeasureWheelData>();
            WheelDamageMeasureDataWheel = new HashSet<WheelDamageMeasureDataWheel>();
        }

        public long WheelId { get; set; }
        public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; }
        public virtual ICollection<HotBoxHotWheelMeasureWheelData> HotBoxHotWheelMeasureWheelData { get; set; }
        public virtual ICollection<WheelDamageMeasureDataWheel> WheelDamageMeasureDataWheel { get; set; }
    }
}
