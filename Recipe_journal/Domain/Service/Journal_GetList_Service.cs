using Recipe_journal.Domain.Class;
using Recipe_journal.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Domain.Service
{
    public class Journal_GetList_Service : IJournal_GetList_Service
    {
        private readonly IGetList_Repository _Repository;

        public Journal_GetList_Service(IGetList_Repository repos)
        {
            _Repository = repos ?? throw new ArgumentNullException(nameof(repos));
        }


        public async Task<JournalGet[]> GetNote(JournalPut put)
        {

            return await _Repository.Get(put);
        }

    }
}
