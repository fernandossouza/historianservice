using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using historianservice.Model;
using historianservice.Service.Interface;

namespace historianservice.Controllers
{
    [Route("api/[controller]")]
    public class HistorianController : Controller
    {
        private readonly IHistorianService _historianService;
        public HistorianController(IHistorianService historianService)
        {
            _historianService = historianService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]int thingId,[FromQuery]long startDate,[FromQuery]long endDate )
        {
            try{
            if(thingId <= 0)
            return StatusCode(500, "thingId <= 0");

            var historian = await _historianService.getHistorian(thingId,startDate,endDate);

            return Ok(historian);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet]
        // public async Task<IActionResult> GetListPerTag([FromQuery]int thingId,[FromQuery]long startDate,[FromQuery]long endDate )
        // {
        //     try{
        //     if(thingId <= 0)
        //     return StatusCode(500, "thingId <= 0");

        //     var historian = await _historianService.getHistorian(thingId,startDate,endDate);

        //     return Ok(historian);
        //     }
        //     catch(Exception ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Historian historian)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    historian.date = DateTime.Now.Ticks;
                    var historianDb = await _historianService.addHistorian(historian);

                    if(historianDb == null)
                    {
                        return StatusCode(500, "erro in insert");
                    }

                    return Ok(historian);
                }

                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}