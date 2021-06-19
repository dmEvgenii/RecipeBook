using Recipe_journal.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Presentation.Models
{
    public class Model_Name
    {
        public string Name { get; set; }


        public JournalPut ToClassName()
        {
            return new JournalPut()
            {
                Name = this.Name
            };

        }

    }
}

