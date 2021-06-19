using IngridientList.Domain.Class;
using IngridientList.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngridientList.Domain.Service
{
    public class IngredientService: IIngredient_Service
    {
        private readonly IIngredient_Repository _Repository;

        public IngredientService(IIngredient_Repository repos)
        {
            _Repository = repos ?? throw new ArgumentNullException(nameof(repos));
        }

        public Task<IngredientList> PutList(PutList put)
        {
            return (_Repository.PutList(put));
        }

    }
}
