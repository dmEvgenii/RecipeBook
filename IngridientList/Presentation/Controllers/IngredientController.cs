using IngridientList.Domain.Interface;
using IngridientList.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngridientList.Presentation.Controllers
{
    [Route("Ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredient_Service _IngredientS;

        public IngredientController(IIngredient_Service Journal_GetList_Service)
        {
            _IngredientS = Journal_GetList_Service ?? throw new ArgumentNullException(nameof(Journal_GetList_Service));
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] IngredientModel model)
        {
            if (model == null)
                return BadRequest("Введите данные");

            try
            {
                return Ok
                    (
                    new ReturnModel(await _IngredientS.PutList(model.ToClass()))
                    );
            }

            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

    }
}
