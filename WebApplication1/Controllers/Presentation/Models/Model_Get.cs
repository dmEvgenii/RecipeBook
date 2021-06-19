using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.Domain.Class;

namespace WebApplication1.Controllers.Presentation.Models
{
    public class Model_Get
    {

        public string name { get; set; }
        public string ingredients { get; set; }

        public string note { get; set; }



        public Model_Get(Start_Put inst)
        {
            name = inst?.Name1 ?? throw new ArgumentNullException(nameof(inst.Name1));
            
            ingredients = inst?.Ingredients ?? throw new ArgumentNullException(nameof(inst.Ingredients));
            note = inst?.Note ?? throw new ArgumentNullException(nameof(inst.Note));

        }

        public Model_Get()
        {


        }





        /*
        public Start_Put ToModelPut()
        {
            return new Start_Put()
            {
                Name = name,
                Ingredients = ingredients,
                Note = note
            };

        }
        */

    }
}
