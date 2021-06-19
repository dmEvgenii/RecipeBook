using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.Domain.Class;
using WebApplication1.Controllers.Domain.Interface;
using WebApplication1.Controllers.Infrastructure.DTO;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Controllers.Infrastructure.Repository
{
    public class StartRepository: IStartRepository
    {

        /*

        private const string CONNECTION_STRING_NAME = "Start";

        private readonly IConfiguration _configuration;

        public StartRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        */
        //postgreSQL
        //private readonly string adres = "Host=docker.host.internal\\PostgreSQL_13;Username=postgres;Password=Lsvjr7397;Database=Test";

        private readonly string adres = "Server=host.docker.internal;Database=Recipe_book;uid=sa;pwd=Qwerty123;";
        //string adres = "Server=Localhost;Database=Recipe_book;Integrated Security=true;";
        public async Task<Start[]> GetStart()
        {


            List<StartDTO> data = new List<StartDTO>();

            //Работа с БД
            using (var connection=new SqlConnection(adres))
            {
                await connection.OpenAsync();
                using var cmd = new SqlCommand("SELECT * FROM dbo.Recipe_List",connection) ;

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                    data.Add(new StartDTO()
                    { 
                        name = reader["Recipe_name"].ToString(),
                        description = reader["Recipe_Description"].ToString()
                    }) ;
            }


            return data.Select(e => e.ToModel()).ToArray();

        }

        public async Task<Start_Put[]> GetData(Start start)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));



            List<StartDTO> data = new List<StartDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(adres))
            {
                

                await connection.OpenAsync();
                using var cmd = new SqlCommand($"SELECT * FROM dbo.Recipe_List WHERE Recipe_Name='{start.Name2}'", connection);

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                    data.Add(new StartDTO()
                    {
                        name = reader["Recipe_name"].ToString(),                       
                        ingredients = reader["Ingredients"].ToString(),
                        note = reader["Note"].ToString()
                    });

            }
            
            return data.Select(e => e.ToModelPut()).ToArray();
        }
    }
}
