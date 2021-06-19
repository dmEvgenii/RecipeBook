using FindRecipe.Domain.Class;
using FindRecipe.Domain.Interface;
using FindRecipe.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace FindRecipe.Infrastructure.Repository
{
    public class FindRepository: IFindRepository
    {
        private readonly string adres = "Server=host.docker.internal;Database=Recipe_book;uid=sa;pwd=Qwerty123;";
        //string adres = "Server=Localhost;Database=Recipe_book;Integrated Security=true;";



        public async Task<FindedRecipe[]> Find(PutList put)
        {


            List<FindDTO> data = new List<FindDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(adres))
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
