using Recipe_journal.Domain.Class;
using Recipe_journal.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Domain.Service
{
    public class JournalAdd_Service : IJournalAdd_Service
    {

        private readonly IAdd_Repository _Repository;

        public JournalAdd_Service(IAdd_Repository repos)
        {
            _Repository = repos ?? throw new ArgumentNullException(nameof(repos));

        }


        public async Task AddNote(JournalPut Put)
        {
            _Repository.AddNote(Put);

        }

    }
}
