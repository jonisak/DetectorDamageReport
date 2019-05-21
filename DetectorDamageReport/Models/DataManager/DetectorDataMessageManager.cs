using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.Models.DataManager
{
    public class DetectorDataMessageManager
    {
        readonly DetectorDamageReportContext _detectorDamageReportContext;

        public DetectorDataMessageManager(DetectorDamageReportContext context)
        {
            _detectorDamageReportContext = context;
        }

        public DetectorDataMessageManager()
        {
            _detectorDamageReportContext = new DetectorDamageReportContext();
        }


        public void Add(DetectorDataMessage detectorDataMessage)
        {
            var message = new Message();
            message.MessageId = Convert.ToInt64(detectorDataMessage.Header.MessageID);
            message.SendTimeStamp = detectorDataMessage.Header.SendTimeStamp;
            message.LocationId = detectorDataMessage.Location.LocationID;
            message.CountryCode = detectorDataMessage.Location.CountryCode;
            message.Owner = detectorDataMessage.Location.Owner;
            message.Track = detectorDataMessage.Location.Track;
            message.TrainOperatorId = _detectorDamageReportContext.TrainOperator.Where(o => o.Name == detectorDataMessage.Train.Operator).FirstOrDefault().TrainOperatorId;
            message.TrainNumber = detectorDataMessage.Train.TrainNumber;
            int trainDir = Convert.ToInt32(detectorDataMessage.Train.Direction);

            if (detectorDataMessage.Train.Direction == "UPTRACK")
            {
                message.TrainDirectionId = 2;
            }
            else if (detectorDataMessage.Train.Direction == "DOWNTRACK")
            {
                message.TrainDirectionId = 2;
            }
            else
            {
                message.TrainDirectionId = 3;
            }
            _detectorDamageReportContext.Message.Add(message);
            _detectorDamageReportContext.SaveChanges();
        }

    }
}
