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
    [Route("api/FindRecipe")]
    [ApiController]
    public class FindRecipeController : ControllerBase
    {


        private IConfiguration _configuration;

        public FindRecipeController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }



        [HttpPost]

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
                    url = _configuration.GetSection("FindRecipeUrl").Value;
                    var result1 = await client.GetAsync($"{url}Find");
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
