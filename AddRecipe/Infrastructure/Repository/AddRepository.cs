using AddRecipe.Domain.Class;
using AddRecipe.Domain.Interface;
using AddRecipe.Infrastructure.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AddRecipe.Infrastructure.Repository
{
    public class AddRepository: IAddRepository
    {
        private const string CONNECTION_STRING_NAME = "Database";

        private readonly IConfiguration _configuration;

        public AddRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


       




        public async Task Add(Add put)
        {

            List<AddDTO> data = new List<AddDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(_configuration.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                await connection.OpenAsync();
                
                    var cmd = new SqlCommand($"INSERT INTO dbo.Recipe_List (Recipe_Name, Recipe_Description, Ingredients,Note) VALUES ('{put.Name}','{put.Description}','{put.Ingredients}','{put.Note}')", connection);

                    cmd.ExecuteNonQuery();           

            }



        }

    }
}
