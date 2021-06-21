using Recipe_journal.Domain.Class;
using Recipe_journal.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Recipe_journal.Infrastrucure.DTO;
using Microsoft.Extensions.Configuration;

namespace Recipe_journal.Infrastrucure.Repository
{
    public class GetList_Repository: IGetList_Repository
    {
        private const string CONNECTION_STRING_NAME = "Database";

        private readonly IConfiguration _configuration;

        public GetList_Repository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<JournalGet[]> Get(JournalPut put)
        {

            List<JournalDTO> data = new List<JournalDTO>();

            //Работа с БД
            using (var connection = new SqlConnection(_configuration.GetConnectionString(CONNECTION_STRING_NAME)))
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
