using FindRecipe.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindRecipe.Presentation.Models
{
    public class IngredientModel
    {
        public string IngredientList { get; set; }


        public IngredientModel()
        {


        }

        
        public PutList ToClass()
        {

            return new PutList
            {                
                IngredientList = this.IngredientList
            };

        }
        

    }
}
