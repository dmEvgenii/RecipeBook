using FindRecipe.Domain.Class;
using FindRecipe.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindRecipe.Domain.Service
{
    public class FindService: IFindService
    {

        private readonly IFindRepository _Repository;

        public FindService(IFindRepository repos)
        {
            _Repository = repos ?? throw new ArgumentNullException(nameof(repos));
        }

        public Task<FindedRecipe[]> Find(PutList put)
        {
            return _Repository.Find(put);
        }



    }
}
