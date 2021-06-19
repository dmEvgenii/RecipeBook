using Recipe_journal.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Domain.Interface
{
    public interface IJournal_GetList_Service
    {

        Task<JournalGet[]> GetNote(JournalPut put);

    }
}
