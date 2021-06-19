using FindRecipe.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRecipe.Domain.Interface
{
    public interface IFindService
    {
        public Task<FindedRecipe[]> Find(PutList put);
    }
}
