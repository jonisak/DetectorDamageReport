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

    public class TrainController : ControllerBase
    {
        // GET: api/Employee
        [HttpPost]
        public ActionResult<List<TrainListDTO>> Get([FromBody] TrainFilterDTO trainFilterDTO)
        {
            return new TrainManager().GetUserTrainList(User.Identity.Name, trainFilterDTO);
        }


        // GET: api/Employee
        [HttpGet("{id}")]
        public ActionResult<TrainDTO> Get(int id)
        {
            return new TrainManager().GetUserTrain(User.Identity.Name, id);
        }

        // GET: api/Employee
        [HttpGet("Login")]
        public ActionResult Login()
        {
            return Ok();
            //return NoContent();
        }

    }
}