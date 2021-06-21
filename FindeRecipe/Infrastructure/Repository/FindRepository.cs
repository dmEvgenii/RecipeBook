using FindRecipe.Domain.Class;
using FindRecipe.Domain.Interface;
using FindRecipe.Infrastructure.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace FindRecipe.Infrastructure.Repository
{
    public class FindRepository: IFindRepository
    {
        private const string CONNECTION_STRING_NAME = "Database";

        private readonly IConfiguration _configuration;

        public FindRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<FindedRecipe[]> Find(PutList put)
        {


            List<FindDTO> data = new List<FindDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(_configuration.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                await connection.OpenAsync();

                //Создание запроса
                
                string Comm = $"SELECT Recipe_name,Recipe_Description FROM dbo.Recipe_List WHERE (Ingredients LIKE '%{put.IngredientList}%')";

                using var cmd = new SqlCommand(Comm, connection);

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                    data.Add(new FindDTO()
                    {
                        Name = reader["Recipe_name"].ToString(),
                        Description = reader["Recipe_Description"].ToString()
                    });
            }


            return data.Select(e => e.ToModel()).ToArray();

        }



    }
}
