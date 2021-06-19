using IngridientList.Domain.Class;
using IngridientList.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IngridientList.Infrastructure.DTO;
using System.Data.SqlClient;

namespace IngridientList.Infrastructure.Repository
{
    public class Ingredient_Repository: IIngredient_Repository
    {

        private readonly string adres = "Server=host.docker.internal;Database=Recipe_book;uid=sa;pwd=Qwerty123;";
        //string adres = "Server=Localhost;Database=Recipe_book;Integrated Security=true;";


        public async Task<IngredientList> PutList(PutList put)
        {

            IngredientDTO data = new IngredientDTO();

            //Работа с БД
            using (var connection = new SqlConnection(adres))
            {
                await connection.OpenAsync();
                using var cmd = new SqlCommand($"SELECT Ingredients FROM dbo.Recipe_List WHERE Recipe_Name='{put.Name}'", connection);

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                    data = new IngredientDTO()
                    {
                        NewList = (reader["Ingredients"].ToString()).Split(',')                       
                    };
            }


            string[] arr = put.Ingredient_List.Split(',');
            string[] newarr;
            int a = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < data.NewList.Length; j++)
                    if (data.NewList[j] == arr[i])
                    {
                        a = 0;
                        newarr = new string[data.NewList.Length - 1];
                        for (int k = 0; k < data.NewList.Length; k++)
                        {
                            if (k != j)
                            {
                                newarr[a] = data.NewList[k];
                                a++;
                            }
                            
                        }
                        data.NewList = newarr;
                    }
            }

            return data.ToModel();

        }

    }
}
