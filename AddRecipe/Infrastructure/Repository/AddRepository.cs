using AddRecipe.Domain.Class;
using AddRecipe.Domain.Interface;
using AddRecipe.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AddRecipe.Infrastructure.Repository
{
    public class AddRepository: IAddRepository
    {



        private readonly string adres = "Server=host.docker.internal;Database=Recipe_book;uid=sa;pwd=Qwerty123;";
        //string adres = "Server=Localhost;Database=Recipe_book;Integrated Security=true;";




        public async Task Add(Add put)
        {

            List<AddDTO> data = new List<AddDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(adres))
            {
                await connection.OpenAsync();
                
                    var cmd = new SqlCommand($"INSERT INTO dbo.Recipe_List (Recipe_Name, Recipe_Description, Ingredients,Note) VALUES ('{put.Name}','{put.Description}','{put.Ingredients}','{put.Note}')", connection);

                    cmd.ExecuteNonQuery();           

            }



        }

    }
}
