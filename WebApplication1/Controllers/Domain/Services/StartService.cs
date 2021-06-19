using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.Domain.Class;
using WebApplication1.Controllers.Domain.Interface;

namespace WebApplication1.Controllers.Domain.Services
{
    public class StartService: IStartService
    {

        private readonly IStartRepository _startRepository;

        public StartService(IStartRepository repos)
        {
            _startRepository = repos ?? throw new ArgumentNullException(nameof(repos));
        }

        

        public async Task<Start[]> GetStart()
        {

            return await _startRepository.GetStart();
           
        }

        public async Task<Start_Put[]> AddData(Start start)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));

           return await _startRepository.GetData(start);
        }
    }
}
