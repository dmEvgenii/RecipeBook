using AddRecipe.Domain.Interface;
using AddRecipe.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRecipe.Presentation.Controllers
{
    [Route("Add")]
    [ApiController]
    public class AddController : ControllerBase
    {

        private readonly IAddService _Add_Service;

        public AddController(IAddService Journal_GetList_Service)
        {
            _Add_Service = Journal_GetList_Service ?? throw new ArgumentNullException(nameof(Journal_GetList_Service));
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AddModel model)
        {
            if (model == null)
                return BadRequest("Введите данные");

            try
            {
                return Ok
                    (
                    _Add_Service.Add(model.ToClass())
                    );
            }

            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }


    }
}
