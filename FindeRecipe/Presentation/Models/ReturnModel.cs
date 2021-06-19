using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindRecipe.Domain.Class;

namespace FindRecipe.Presentation.Models
{
    public class ReturnModel
    {
        public string Name { get; set; }

        public string Description { get; set; }



        public ReturnModel()
        {


        }

        public ReturnModel(FindedRecipe x)
        {
            Name = x.Name;
            Description = x.Description;
        }


    }
}
