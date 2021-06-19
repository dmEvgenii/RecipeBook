using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.Domain.Class;

namespace WebApplication1.Controllers.Domain.Interface
{
    public interface IStartService
    {
        Task<Start[]> GetStart();

        Task<Start_Put[]> AddData(Start start);


    }
}
