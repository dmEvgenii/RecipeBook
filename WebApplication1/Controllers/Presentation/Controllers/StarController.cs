using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Domain.Interface;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers.Presentation.Controllers
{
    [ApiController]
    [Route(template: "Start")]
    public class StarController : ControllerBase
    {
        private readonly IStartService _startService;

        public StarController(IStartService startService)
        {
            _startService = startService ?? throw new ArgumentNullException(nameof(startService));
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {


           

            try
            {

                return Ok((await _startService.GetStart()).Select(x => new StartModel(x)));
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        
        [HttpPut]
        public async Task<ActionResult> Put([FromBody]StartModel model)
        {
            Console.WriteLine("a");
            if (model == null)
                return BadRequest("Введите данные");

            try
            {

                
                return Ok
                    (
                     (await _startService.AddData(model.ToClass())).Select(x => new Model_Get(x))
                    );
            }

            catch (Exception e)
            {
                
                return Ok(e.Message);
            }
        }
        


    }
}
