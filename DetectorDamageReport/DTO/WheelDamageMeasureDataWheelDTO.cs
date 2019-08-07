namespace DetectorDamageReport.DTO
{
    public class WheelDamageMeasureDataWheelDTO
    {
        public double WheelDamageMeasureDataWheelId { get; set; }
        public double? LeftWheelDamageDistributedLoadValue { get; set; }
        public double? LeftWheelDamageMeanValue { get; set; }
        public double? LeftWheelDamagePeakValue { get; set; }
        public double? LeftWheelDamageQualityFactor { get; set; }
        public double? RightWheelDamageDistributedLoadValue { get; set; }
        public double? RightWheelDamageMeanValue { get; set; }
        public double? RightWheelDamagePeakValue { get; set; }
        public double? RightWheelDamageQualityFactor { get; set; }
    }
}