using AddRecipe.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRecipe.Domain.Interface
{
    public interface IAddRepository
    {
        public Task Add(Add put);
    }
}
