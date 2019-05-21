using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public class ImportController : ControllerBase
    {



        public ImportController()
        {

        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] DetectorDataMessage detectorDataMessage)
        {
            if (detectorDataMessage == null)
            {
                return BadRequest("DetectorDataMessage is null.");
            }

           new DetectorDataMessageManager().Add(detectorDataMessage);


            return null;


            ////_dataRepository.Add(user);
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = user.UserId },
            //      user);
        }

        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(long id)
        //{
        //    User employee = _dataRepository.Get(id);

        //    if (employee == null)
        //    {
        //        return NotFound("The Employee record couldn't be found.");
        //    }

        //    return Ok(employee);
        //}

    }
}