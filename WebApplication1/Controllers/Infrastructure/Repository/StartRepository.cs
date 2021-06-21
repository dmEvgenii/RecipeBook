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

        private const string CONNECTION_STRING_NAME = "Database";

        private readonly IConfiguration _configuration;

        public StartRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        public async Task<Start[]> GetStart()
        {


            List<StartDTO> data = new List<StartDTO>();

            //Работа с БД
            using (var connection=new SqlConnection(_configuration.GetConnectionString(CONNECTION_STRING_NAME)))
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
            using (var connection = new SqlConnection(_configuration.GetConnectionString(CONNECTION_STRING_NAME)))
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
