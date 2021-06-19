using IngridientList.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngridientList.Infrastructure.DTO
{
    public class IngredientDTO
    {
        public string[] NewList { get; set; }

        public IngredientList ToModel()
        {
            return new IngredientList()
            {
                IList = NewList
            };

        }

    }
}
