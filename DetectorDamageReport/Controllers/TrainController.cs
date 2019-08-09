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
        public ActionResult<List<TrainDTO>> GetUserTrains([FromBody] PagingDTO pagingDTO)
        {
            return new TrainManager().GetUserTrains(User.Identity.Name, pagingDTO);
        }
    }
}