using AddRecipe.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRecipe.Presentation.Models
{
    public class AddModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Note { get; set; }



        public AddModel()
        {

        }


        public Add ToClass()
        {
            return new Add
            {
                Name = this.Name,
                Description=this.Description,
                Ingredients=this.Ingredients,
                Note=this.Note
            };
        }


    }
}
