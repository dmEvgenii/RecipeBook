using Recipe_journal.Domain.Class;
using Recipe_journal.Domain.Interface;
using Recipe_journal.Infrastrucure.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Infrastrucure.Repository
{
    public class Add_Repository: IAdd_Repository
    {
        private readonly string adres = "Server=host.docker.internal;Database=Recipe_book;uid=sa;pwd=Qwerty123;";
        //string adres = "Server=Localhost;Database=Recipe_book;Integrated Security=true;";




        public async Task AddNote(JournalPut put)
        {

            List<JournalDTO> data = new List<JournalDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(adres))
            {
                await connection.OpenAsync();
                var cmd = new SqlCommand($"UPDATE dbo.Recipe_Result SET Result=Result+'{put.Result}',Remarks='{put.Remarks}' WHERE Recipe_Name='{put.Name}'", connection);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    cmd = new SqlCommand($"INSERT INTO dbo.Recipe_Result (Recipe_Name, Result, Remarks) VALUES ('{put.Name}','{put.Result}','{put.Remarks}')", connection);
                    cmd.ExecuteNonQuery();
                }
                
            }   



        }


    }
}
