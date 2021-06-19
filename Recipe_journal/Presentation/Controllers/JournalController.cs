using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe_journal.Domain.Interface;
using Recipe_journal.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Presentation.Controllers
{
    [Route(template: "Journal")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournal_GetList_Service _Journal_GetList_Service;

        public JournalController(IJournal_GetList_Service Journal_GetList_Service)
        {
            _Journal_GetList_Service = Journal_GetList_Service ?? throw new ArgumentNullException(nameof(Journal_GetList_Service));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Model_Put model)
        {
            if (model == null)
                return BadRequest("Введите данные");

            try
            {
                return Ok
                    (
                    (await _Journal_GetList_Service.GetNote(model.ToClassName())).Select(x => new Model_Put(x))
                    ) ;
            }

            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }



        



    }
}
