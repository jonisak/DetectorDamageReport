using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetectorDamageReport.DTO;
using DetectorDamageReport.Models;
using DetectorDamageReport.Models.DataManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DetectorDamageReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AlarmReportController : ControllerBase
    {


        public AlarmReportController()
        {

        }
        [HttpPost]
        public IActionResult Post([FromBody] AlarmReportDTO alarmReportDTO)
        {
            if (alarmReportDTO == null)
            {
                return BadRequest("AlarmReportDTO is null.");
            }
            new AlarmReportManager().Add(alarmReportDTO);
            return Ok();
        }


        [HttpPost]
        public ActionResult<List<TrainListDTO>> Get([FromBody] TrainFilterDTO trainFilterDTO)
        {
            return new TrainManager().GetUserTrainList(User.Identity.Name, trainFilterDTO, getAlarmsOnly:true);
        }



    }
}