using AddRecipe.Domain.Class;
using AddRecipe.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRecipe.Domain.Service
{
    public class AddService: IAddService
    {
        private readonly IAddRepository _Repository;

        public AddService(IAddRepository repos)
        {
            _Repository = repos ?? throw new ArgumentNullException(nameof(repos));

        }

        public async Task Add(Add Put)
        {
            _Repository.Add(Put);

        }


    }
}
