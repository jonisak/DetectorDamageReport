using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetectorDamageReport.DTO;

namespace DetectorDamageReport.Models.DataManager
{
    public class TrainManager
    {
        readonly DetectorDamageReportContext _detectorDamageReportContext;
        public TrainManager(DetectorDamageReportContext context)
        {
            _detectorDamageReportContext = context;
        }
        public TrainManager()
        {
            _detectorDamageReportContext = new DetectorDamageReportContext();
        }

        public List<TrainDTO> GetUserTrains(String userId)
        {
           // int uid = Convert.ToInt32(userId);

            //Ta fram en lista med användarens alla tågoperatörer
            var trainoperators = _detectorDamageReportContext.TrainOperatorUser.Where(o => o.User.UserName == userId).Select(o => o.TrainOperatorId).Distinct().ToList();

            var trains = _detectorDamageReportContext.Train
                               .Where(t => trainoperators.Contains(t.TrainOperatorId));



            List<TrainDTO> trainDTOs = new List<TrainDTO>();

            foreach (var train in trains)
            {

                foreach (var vechicle in train.Vehicle)
                {

                }

                trainDTOs.Add(new TrainDTO()
                {
                    TrainId = train.TrainId,
                    TrainDirection = train.TrainDirection.Name,
                    TrainNumber = train.TrainNumber,
                    TrainOperator = train.TrainOperator.Name,
                    MessageSent = train.Message.SendTimeStamp.ToShortDateString(),
                    Detector = train.Message.LocationId





                });
               
            }
            return trainDTOs;
        }
    }
}
