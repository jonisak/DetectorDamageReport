﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.7.3081.0.
// 
namespace DetectorDamageReport.Models
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DetectorDataMessage
    {

        private HeaderType headerField;

        private LocationType locationField;

        private TrainType trainField;

        private SubscriberDestinationType subscriberDestinationField;

        /// <remarks/>
        public HeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public LocationType Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        public TrainType Train
        {
            get
            {
                return this.trainField;
            }
            set
            {
                this.trainField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
        public SubscriberDestinationType SubscriberDestination
        {
            get
            {
                return this.subscriberDestinationField;
            }
            set
            {
                this.subscriberDestinationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HeaderType
    {

        private string messageIDField;

        private string vendorField;

        private string softwareVersionField;

        private System.DateTime sendTimeStampField;

        /// <remarks/>
        public string MessageID
        {
            get
            {
                return this.messageIDField;
            }
            set
            {
                this.messageIDField = value;
            }
        }

        /// <remarks/>
        public string Vendor
        {
            get
            {
                return this.vendorField;
            }
            set
            {
                this.vendorField = value;
            }
        }

        /// <remarks/>
        public string SoftwareVersion
        {
            get
            {
                return this.softwareVersionField;
            }
            set
            {
                this.softwareVersionField = value;
            }
        }

        /// <remarks/>
        public System.DateTime SendTimeStamp
        {
            get
            {
                return this.sendTimeStampField;
            }
            set
            {
                this.sendTimeStampField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
    [System.Xml.Serialization.XmlRootAttribute("SubscriberDestination", Namespace = "urn:se:trafikverket:extension:xsd:1", IsNullable = false)]
    public partial class SubscriberDestinationType
    {

        private string subscriberDesinationURNField;

        private int subscriberDesinationTypeField;

        private bool subscriberDesinationTypeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubscriberDesinationURN
        {
            get
            {
                return this.subscriberDesinationURNField;
            }
            set
            {
                this.subscriberDesinationURNField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SubscriberDesinationType
        {
            get
            {
                return this.subscriberDesinationTypeField;
            }
            set
            {
                this.subscriberDesinationTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubscriberDesinationTypeSpecified
        {
            get
            {
                return this.subscriberDesinationTypeFieldSpecified;
            }
            set
            {
                this.subscriberDesinationTypeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
    [System.Xml.Serialization.XmlRootAttribute("TagID", Namespace = "urn:se:trafikverket:extension:xsd:1", IsNullable = false)]
    public partial class TagIDType
    {

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class WheelType
    {

        private MeasurementDataType[] measurementValuesField;

        private AlertType[] alertField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MeasurementValues")]
        public MeasurementDataType[] MeasurementValues
        {
            get
            {
                return this.measurementValuesField;
            }
            set
            {
                this.measurementValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Alert")]
        public AlertType[] Alert
        {
            get
            {
                return this.alertField;
            }
            set
            {
                this.alertField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MeasurementDataType
    {

        private string deviceTypeField;

        private string softwareVersionField;

        private string hardwareVersionField;

        private string vendorField;

        private MeasurementDataTypeMeasurementData measurementDataField;

        /// <remarks/>
        public string DeviceType
        {
            get
            {
                return this.deviceTypeField;
            }
            set
            {
                this.deviceTypeField = value;
            }
        }

        /// <remarks/>
        public string SoftwareVersion
        {
            get
            {
                return this.softwareVersionField;
            }
            set
            {
                this.softwareVersionField = value;
            }
        }

        /// <remarks/>
        public string HardwareVersion
        {
            get
            {
                return this.hardwareVersionField;
            }
            set
            {
                this.hardwareVersionField = value;
            }
        }

        /// <remarks/>
        public string Vendor
        {
            get
            {
                return this.vendorField;
            }
            set
            {
                this.vendorField = value;
            }
        }

        /// <remarks/>
        public MeasurementDataTypeMeasurementData MeasurementData
        {
            get
            {
                return this.measurementDataField;
            }
            set
            {
                this.measurementDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MeasurementDataTypeMeasurementData
    {

        private HotBoxHotWheelMeasureDataWheelType hotBoxHotWheelMeasureWheelDataField;

        private WheelDamageMeasureDataAxleType wheelDamageMeasureDataAxleField;

        private WheelDamageMeasureDataWheelType wheelDamageMeasureDataWheelField;

        private WheelDamageMeasureDataVehicleType wheelDamageMeasureDataVehicleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
        public HotBoxHotWheelMeasureDataWheelType HotBoxHotWheelMeasureWheelData
        {
            get
            {
                return this.hotBoxHotWheelMeasureWheelDataField;
            }
            set
            {
                this.hotBoxHotWheelMeasureWheelDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
        public WheelDamageMeasureDataAxleType WheelDamageMeasureDataAxle
        {
            get
            {
                return this.wheelDamageMeasureDataAxleField;
            }
            set
            {
                this.wheelDamageMeasureDataAxleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
        public WheelDamageMeasureDataWheelType WheelDamageMeasureDataWheel
        {
            get
            {
                return this.wheelDamageMeasureDataWheelField;
            }
            set
            {
                this.wheelDamageMeasureDataWheelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
        public WheelDamageMeasureDataVehicleType WheelDamageMeasureDataVehicle
        {
            get
            {
                return this.wheelDamageMeasureDataVehicleField;
            }
            set
            {
                this.wheelDamageMeasureDataVehicleField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
    [System.Xml.Serialization.XmlRootAttribute("HotBoxHotWheelMeasureWheelData", Namespace = "urn:se:trafikverket:extension:xsd:1", IsNullable = false)]
    public partial class HotBoxHotWheelMeasureDataWheelType
    {

        private float hotBoxLeftValueField;

        private bool hotBoxLeftValueFieldSpecified;

        private float hotBoxRightValueField;

        private bool hotBoxRightValueFieldSpecified;

        private float hotWheelLeftValueField;

        private bool hotWheelLeftValueFieldSpecified;

        private float hotWheelRightValueField;

        private bool hotWheelRightValueFieldSpecified;

        /// <remarks/>
        public float HotBoxLeftValue
        {
            get
            {
                return this.hotBoxLeftValueField;
            }
            set
            {
                this.hotBoxLeftValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HotBoxLeftValueSpecified
        {
            get
            {
                return this.hotBoxLeftValueFieldSpecified;
            }
            set
            {
                this.hotBoxLeftValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float HotBoxRightValue
        {
            get
            {
                return this.hotBoxRightValueField;
            }
            set
            {
                this.hotBoxRightValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HotBoxRightValueSpecified
        {
            get
            {
                return this.hotBoxRightValueFieldSpecified;
            }
            set
            {
                this.hotBoxRightValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float HotWheelLeftValue
        {
            get
            {
                return this.hotWheelLeftValueField;
            }
            set
            {
                this.hotWheelLeftValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HotWheelLeftValueSpecified
        {
            get
            {
                return this.hotWheelLeftValueFieldSpecified;
            }
            set
            {
                this.hotWheelLeftValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float HotWheelRightValue
        {
            get
            {
                return this.hotWheelRightValueField;
            }
            set
            {
                this.hotWheelRightValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HotWheelRightValueSpecified
        {
            get
            {
                return this.hotWheelRightValueFieldSpecified;
            }
            set
            {
                this.hotWheelRightValueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
    [System.Xml.Serialization.XmlRootAttribute("WheelDamageMeasureDataAxle", Namespace = "urn:se:trafikverket:extension:xsd:1", IsNullable = false)]
    public partial class WheelDamageMeasureDataAxleType
    {

        private float axleLoadField;

        private bool axleLoadFieldSpecified;

        private float leftRightLoadRatioField;

        private bool leftRightLoadRatioFieldSpecified;

        /// <remarks/>
        public float AxleLoad
        {
            get
            {
                return this.axleLoadField;
            }
            set
            {
                this.axleLoadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AxleLoadSpecified
        {
            get
            {
                return this.axleLoadFieldSpecified;
            }
            set
            {
                this.axleLoadFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float LeftRightLoadRatio
        {
            get
            {
                return this.leftRightLoadRatioField;
            }
            set
            {
                this.leftRightLoadRatioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeftRightLoadRatioSpecified
        {
            get
            {
                return this.leftRightLoadRatioFieldSpecified;
            }
            set
            {
                this.leftRightLoadRatioFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
    [System.Xml.Serialization.XmlRootAttribute("WheelDamageMeasureDataWheel", Namespace = "urn:se:trafikverket:extension:xsd:1", IsNullable = false)]
    public partial class WheelDamageMeasureDataWheelType
    {

        private float leftWheelDamageDistributedLoadValueField;

        private bool leftWheelDamageDistributedLoadValueFieldSpecified;

        private float leftWheelDamageMeanValueField;

        private bool leftWheelDamageMeanValueFieldSpecified;

        private float leftWheelDamagePeakValueField;

        private bool leftWheelDamagePeakValueFieldSpecified;

        private float leftWheelDamageQualityFactorField;

        private bool leftWheelDamageQualityFactorFieldSpecified;

        private float rightWheelDamageDistributedLoadValueField;

        private bool rightWheelDamageDistributedLoadValueFieldSpecified;

        private float rightWheelDamageMeanValueField;

        private bool rightWheelDamageMeanValueFieldSpecified;

        private float rightWheelDamagePeakValueField;

        private bool rightWheelDamagePeakValueFieldSpecified;

        private float rightWheelDamageQualityFactorField;

        private bool rightWheelDamageQualityFactorFieldSpecified;

        /// <remarks/>
        public float LeftWheelDamageDistributedLoadValue
        {
            get
            {
                return this.leftWheelDamageDistributedLoadValueField;
            }
            set
            {
                this.leftWheelDamageDistributedLoadValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeftWheelDamageDistributedLoadValueSpecified
        {
            get
            {
                return this.leftWheelDamageDistributedLoadValueFieldSpecified;
            }
            set
            {
                this.leftWheelDamageDistributedLoadValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float LeftWheelDamageMeanValue
        {
            get
            {
                return this.leftWheelDamageMeanValueField;
            }
            set
            {
                this.leftWheelDamageMeanValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeftWheelDamageMeanValueSpecified
        {
            get
            {
                return this.leftWheelDamageMeanValueFieldSpecified;
            }
            set
            {
                this.leftWheelDamageMeanValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float LeftWheelDamagePeakValue
        {
            get
            {
                return this.leftWheelDamagePeakValueField;
            }
            set
            {
                this.leftWheelDamagePeakValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeftWheelDamagePeakValueSpecified
        {
            get
            {
                return this.leftWheelDamagePeakValueFieldSpecified;
            }
            set
            {
                this.leftWheelDamagePeakValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float LeftWheelDamageQualityFactor
        {
            get
            {
                return this.leftWheelDamageQualityFactorField;
            }
            set
            {
                this.leftWheelDamageQualityFactorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeftWheelDamageQualityFactorSpecified
        {
            get
            {
                return this.leftWheelDamageQualityFactorFieldSpecified;
            }
            set
            {
                this.leftWheelDamageQualityFactorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float RightWheelDamageDistributedLoadValue
        {
            get
            {
                return this.rightWheelDamageDistributedLoadValueField;
            }
            set
            {
                this.rightWheelDamageDistributedLoadValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RightWheelDamageDistributedLoadValueSpecified
        {
            get
            {
                return this.rightWheelDamageDistributedLoadValueFieldSpecified;
            }
            set
            {
                this.rightWheelDamageDistributedLoadValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float RightWheelDamageMeanValue
        {
            get
            {
                return this.rightWheelDamageMeanValueField;
            }
            set
            {
                this.rightWheelDamageMeanValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RightWheelDamageMeanValueSpecified
        {
            get
            {
                return this.rightWheelDamageMeanValueFieldSpecified;
            }
            set
            {
                this.rightWheelDamageMeanValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float RightWheelDamagePeakValue
        {
            get
            {
                return this.rightWheelDamagePeakValueField;
            }
            set
            {
                this.rightWheelDamagePeakValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RightWheelDamagePeakValueSpecified
        {
            get
            {
                return this.rightWheelDamagePeakValueFieldSpecified;
            }
            set
            {
                this.rightWheelDamagePeakValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float RightWheelDamageQualityFactor
        {
            get
            {
                return this.rightWheelDamageQualityFactorField;
            }
            set
            {
                this.rightWheelDamageQualityFactorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RightWheelDamageQualityFactorSpecified
        {
            get
            {
                return this.rightWheelDamageQualityFactorFieldSpecified;
            }
            set
            {
                this.rightWheelDamageQualityFactorFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
    [System.Xml.Serialization.XmlRootAttribute("WheelDamageMeasureDataVehicle", Namespace = "urn:se:trafikverket:extension:xsd:1", IsNullable = false)]
    public partial class WheelDamageMeasureDataVehicleType
    {

        private float frontRearLoadRatioField;

        private float leftRightLoadRatioField;

        private float weightInTonsField;

        /// <remarks/>
        public float FrontRearLoadRatio
        {
            get
            {
                return this.frontRearLoadRatioField;
            }
            set
            {
                this.frontRearLoadRatioField = value;
            }
        }

        /// <remarks/>
        public float LeftRightLoadRatio
        {
            get
            {
                return this.leftRightLoadRatioField;
            }
            set
            {
                this.leftRightLoadRatioField = value;
            }
        }

        /// <remarks/>
        public float WeightInTons
        {
            get
            {
                return this.weightInTonsField;
            }
            set
            {
                this.weightInTonsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AlertType
    {

        private string measurementTypeField;

        private string decriptionTextField;

        private string alarmCodeField;

        private string levelField;

        /// <remarks/>
        public string MeasurementType
        {
            get
            {
                return this.measurementTypeField;
            }
            set
            {
                this.measurementTypeField = value;
            }
        }

        /// <remarks/>
        public string DecriptionText
        {
            get
            {
                return this.decriptionTextField;
            }
            set
            {
                this.decriptionTextField = value;
            }
        }

        /// <remarks/>
        public string AlarmCode
        {
            get
            {
                return this.alarmCodeField;
            }
            set
            {
                this.alarmCodeField = value;
            }
        }

        /// <remarks/>
        public string Level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AxleType
    {

        private string axleNumberField;

        private MeasurementDataType[] measurementValuesField;

        private AlertType[] alertField;

        private WheelType[] wheelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string AxleNumber
        {
            get
            {
                return this.axleNumberField;
            }
            set
            {
                this.axleNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MeasurementValues")]
        public MeasurementDataType[] MeasurementValues
        {
            get
            {
                return this.measurementValuesField;
            }
            set
            {
                this.measurementValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Alert")]
        public AlertType[] Alert
        {
            get
            {
                return this.alertField;
            }
            set
            {
                this.alertField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Wheel")]
        public WheelType[] Wheel
        {
            get
            {
                return this.wheelField;
            }
            set
            {
                this.wheelField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VehicleType
    {

        private string vehicleNumberField;

        private float speedField;

        private string axleCountField;

        private MeasurementDataType[] measurementValuesField;

        private AlertType[] alertField;

        private AxleType[] axleField;

        private TagIDType tagIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string VehicleNumber
        {
            get
            {
                return this.vehicleNumberField;
            }
            set
            {
                this.vehicleNumberField = value;
            }
        }

        /// <remarks/>
        public float Speed
        {
            get
            {
                return this.speedField;
            }
            set
            {
                this.speedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string AxleCount
        {
            get
            {
                return this.axleCountField;
            }
            set
            {
                this.axleCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MeasurementValues")]
        public MeasurementDataType[] MeasurementValues
        {
            get
            {
                return this.measurementValuesField;
            }
            set
            {
                this.measurementValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Alert")]
        public AlertType[] Alert
        {
            get
            {
                return this.alertField;
            }
            set
            {
                this.alertField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Axle")]
        public AxleType[] Axle
        {
            get
            {
                return this.axleField;
            }
            set
            {
                this.axleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:se:trafikverket:extension:xsd:1")]
        public TagIDType TagID
        {
            get
            {
                return this.tagIDField;
            }
            set
            {
                this.tagIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TrainType
    {

        private string operatorField;

        private string trainNumberField;

        private string directionField;

        private string vehicleCountField;

        private MeasurementDataType[] measurementValuesField;

        private AlertType[] alertField;

        private VehicleType[] vehicleField;

        /// <remarks/>
        public string Operator
        {
            get
            {
                return this.operatorField;
            }
            set
            {
                this.operatorField = value;
            }
        }

        /// <remarks/>
        public string TrainNumber
        {
            get
            {
                return this.trainNumberField;
            }
            set
            {
                this.trainNumberField = value;
            }
        }

        /// <remarks/>
        public string Direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string VehicleCount
        {
            get
            {
                return this.vehicleCountField;
            }
            set
            {
                this.vehicleCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MeasurementValues")]
        public MeasurementDataType[] MeasurementValues
        {
            get
            {
                return this.measurementValuesField;
            }
            set
            {
                this.measurementValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Alert")]
        public AlertType[] Alert
        {
            get
            {
                return this.alertField;
            }
            set
            {
                this.alertField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Vehicle")]
        public VehicleType[] Vehicle
        {
            get
            {
                return this.vehicleField;
            }
            set
            {
                this.vehicleField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LocationType
    {

        private string locationIDField;

        private string countryCodeField;

        private string ownerField;

        private string trackField;

        private string trackSectionField;

        /// <remarks/>
        public string LocationID
        {
            get
            {
                return this.locationIDField;
            }
            set
            {
                this.locationIDField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string Owner
        {
            get
            {
                return this.ownerField;
            }
            set
            {
                this.ownerField = value;
            }
        }

        /// <remarks/>
        public string Track
        {
            get
            {
                return this.trackField;
            }
            set
            {
                this.trackField = value;
            }
        }

        /// <remarks/>
        public string TrackSection
        {
            get
            {
                return this.trackSectionField;
            }
            set
            {
                this.trackSectionField = value;
            }
        }
    }
}