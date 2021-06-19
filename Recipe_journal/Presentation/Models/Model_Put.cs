using Recipe_journal.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_journal.Presentation.Models
{
    public class Model_Put
    {
        public string Name { get; set; }
        public string Result { get; set; }
        public string Remark { get; set; }


        public Model_Put()
        {

        }



        public JournalPut ToClass()
        {
            return new JournalPut()
            {
                Name = this.Name,
                Result=this.Result,
                Remarks=this.Remark
            };
        }


        public JournalPut ToClassName()
        {
            return new JournalPut()
            {
                Name = this.Name
            };

        }

        public Model_Put(JournalGet x)
        {
            Name = x.Name;
            Result = x.Result;
            Remark = x.Remarks;

        }

    }
}
