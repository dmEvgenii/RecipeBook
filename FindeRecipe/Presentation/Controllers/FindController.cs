using FindRecipe.Domain.Interface;
using FindRecipe.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace FindRecipe.Presentation.Controllers
{
    [Route("Find")]
    [ApiController]
    public class FindController : ControllerBase
    {
        private readonly IFindService _FindeService;

        public FindController(IFindService Journal_GetList_Service)
        {
            _FindeService = Journal_GetList_Service ?? throw new ArgumentNullException(nameof(Journal_GetList_Service));
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
                    (await _FindeService.Find(model.ToClass())).Select(x => new ReturnModel(x))
                    );
            }

            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }


    }
}
