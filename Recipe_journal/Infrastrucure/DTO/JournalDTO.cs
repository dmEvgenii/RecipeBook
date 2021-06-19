using Recipe_journal.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Infrastrucure.DTO
{
    public class JournalDTO
    {
        public string Name { get; set; }

        public string Result { get; set; }

        public string Remarks { get; set; }


        public JournalGet ToModel()
        {
            return new JournalGet()
            {
                Name=this.Name,
                Result=this.Result,
                Remarks=this.Remarks
            };

        }

    }
}
