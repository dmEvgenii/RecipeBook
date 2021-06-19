using Recipe_journal.Domain.Class;
using Recipe_journal.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Recipe_journal.Infrastrucure.DTO;

namespace Recipe_journal.Infrastrucure.Repository
{
    public class GetList_Repository: IGetList_Repository
    {
        private readonly string adres = "Server=host.docker.internal;Database=Recipe_book;uid=sa;pwd=Qwerty123;";
        //string adres = "Server=Localhost;Database=Recipe_book;Integrated Security=true;";


        public async Task<JournalGet[]> Get(JournalPut put)
        {

            List<JournalDTO> data = new List<JournalDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(adres))
            {
                await connection.OpenAsync();
                using var cmd = new SqlCommand($"SELECT * FROM dbo.Recipe_Result WHERE Recipe_Name='{put.Name}'", connection);

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                    data.Add(new JournalDTO()
                    {
                        Name = reader["Recipe_Name"].ToString(),
                        Result = reader["Result"].ToString(),
                        Remarks = reader["Remarks"].ToString()
                    });
            }


            return data.Select(e => e.ToModel()).ToArray();

        }

    }
}
