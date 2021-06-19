using IngridientList.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngridientList.Presentation.Models
{
    public class ReturnModel
    {





        public string[] IngredientList { get; set; }



        public ReturnModel()
        {


        }

        public ReturnModel(IngredientList x)
        {
            IngredientList = x.IList;
        }
    }
}
