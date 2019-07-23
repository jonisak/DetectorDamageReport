namespace DetectorDamageReport.DTO
{
    public class WheelDamageMeasureDataWheelDTO
    {
        public double WheelDamageMeasureDataWheelId { get; set; }
        public float? LeftWheelDamageDistributedLoadValue { get; set; }
        public float? LeftWheelDamageMeanValue { get; set; }
        public float? LeftWheelDamagePeakValue { get; set; }
        public float? LeftWheelDamageQualityFactor { get; set; }
        public float? RightWheelDamageDistributedLoadValue { get; set; }
        public float? RightWheelDamageMeanValue { get; set; }
        public float? RightWheelDamagePeakValue { get; set; }
        public float? RightWheelDamageQualityFactor { get; set; }
    }
}