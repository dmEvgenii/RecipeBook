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
    [Route("JournalAdd")]
    [ApiController]
    public class JournalAddController : ControllerBase
    {

        private readonly IJournalAdd_Service _Add_Service;

        public JournalAddController(IJournalAdd_Service Journal_GetList_Service)
        {
            _Add_Service = Journal_GetList_Service ?? throw new ArgumentNullException(nameof(Journal_GetList_Service));
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
                    _Add_Service.AddNote(model.ToClass())
                    );
            }

            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }



    }
}
