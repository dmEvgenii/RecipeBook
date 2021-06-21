using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    [Route("api/Journal")]
    [ApiController]
    public class JournalController : ControllerBase
    {



        private IConfiguration _configuration;

        public JournalController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        [HttpPut]

        public async Task<IActionResult> PutStartApp()
        {
            var url = _configuration.GetSection("Dsn").Value;
            var logger = new LoggerConfiguration()
                .WriteTo.Sentry(url)
                .Enrich.FromLogContext()
                .CreateLogger();


            try
            {

                using (HttpClient client = new HttpClient())
                {
                    url = _configuration.GetSection("JournalUrl").Value;
                    var result1 = await client.GetAsync($"{url}Journal");
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
