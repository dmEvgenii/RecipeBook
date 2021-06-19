using IngridientList.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngridientList.Presentation.Models
{
    public class IngredientModel
    {

        public string Name { get; set; }

        public string IngredientList { get; set; }



        public IngredientModel()
        {


        }

       


        public PutList ToClass()
        {

            return new PutList
            {
                Name = this.Name,
                Ingredient_List = this.IngredientList
            };

        }


    }
}
