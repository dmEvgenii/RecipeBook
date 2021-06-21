using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    [Route("api/JournalAdd")]
    [ApiController]
    public class JournalAddController : ControllerBase
    {


       


        [HttpPut]

        public async Task<IActionResult> PutStartApp()
        {

            var logger = new LoggerConfiguration()
                .WriteTo.Sentry("https://37366873538a48b6a45ba3163f63f482@o829940.ingest.sentry.io/5812140")
                .Enrich.FromLogContext()
                .CreateLogger();


            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var result1 = await client.GetAsync("http://127.17.0.2/JournalAdd");
                    result1.EnsureSuccessStatusCode();
                    var result = await result1.Content.ReadAsStringAsync();
                    return Ok(result1);
                }
            }
            catch (Exception e)
            {

                logger.Fatal(e, "Произошла фатальная ошибка");
                return StatusCode(StatusCodes.Status500InternalServerError, e);

            }

        }

    }
}
