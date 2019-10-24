using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetectorDamageReport.DTO;
using DetectorDamageReport.Models.DataManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DetectorDamageReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetectorController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<DetectorDTO>> Get()
        {
            return new DetectorManager().GetDetectorList();
        }
    }
}