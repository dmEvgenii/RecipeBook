using IngridientList.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngridientList.Domain.Interface
{
    public interface IIngredient_Repository
    {


        public Task<IngredientList> PutList(PutList put);
    }
}
