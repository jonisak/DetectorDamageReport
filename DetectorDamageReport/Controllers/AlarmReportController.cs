using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DetectorDamageReport.Models.DataManager;
using DetectorDamageReport.DTO;

namespace DetectorDamageReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AlarmReportController : ControllerBase
    {



        [HttpPost]
        public ActionResult<List<TrainListDTO>> Get([FromBody] TrainFilterDTO trainFilterDTO)
        {
            return new TrainManager().GetUserTrainList(User.Identity.Name, trainFilterDTO, true);
        }

        [HttpGet("{id}")]
        public ActionResult<AlarmReportDTO> Get(int id)
        {
            var alarmReport = new AlarmReportManager().GetAlarmReportByTrainId(id);
            if (alarmReport == null)
            {
                return NotFound("alarmReport is null.");
            }

            return alarmReport;

        }



        [Route("GetAlarmReportById")]
        [HttpGet("{id}")]
        ActionResult<AlarmReportDTO> GetAlarmReportById(int id)
        {

            var alarmReport = new AlarmReportManager().GetAlarmReportById(id);
            if (alarmReport == null)
            {
                return NotFound("alarmReport is null.");
            }

            return alarmReport;


        }




        [HttpPut("{id}")]
        public ActionResult<AlarmReportDTO> Put(int id, [FromBody] AlarmReportDTO alarmReportDTO)
        {
            if (alarmReportDTO == null)
            {
                return BadRequest("Alarmreport is null.");
            }

            AlarmReportDTO alarmReportToUpdate = new AlarmReportManager().GetAlarmReportById(id);
            if (alarmReportToUpdate == null)
            {
                return NotFound("AlarmReport not found");
            }
            return new AlarmReportManager().UpdateAlarmReport(alarmReportDTO);
        }


        [Route("SaveAlarmReport")]
        [HttpPost]
        public ActionResult<AlarmReportDTO> Post([FromBody] AlarmReportDTO alarmReportDTO)
        {
            if (alarmReportDTO == null)
            {
                return BadRequest("Alarmreport is null.");
            }


            return new AlarmReportManager().Add(alarmReportDTO);
        }


        [Route("UploadAlarmReportImage")]
        [HttpPost]
        public ActionResult UploadAlarmReportImage([FromBody] AlarmReportImageDTO alarmReportImageDTO)
        {
            if (alarmReportImageDTO == null)
            {
                return BadRequest("AlarmreportImage is null.");
            }


            new AlarmReportManager().UploadAlarmReportImage(alarmReportImageDTO);
            return Ok();
        }

    }
}