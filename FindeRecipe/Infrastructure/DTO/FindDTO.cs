using FindRecipe.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRecipe.Infrastructure.DTO
{
    public class FindDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }




        public FindedRecipe ToModel()
        {
            return new FindedRecipe
            {
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}
