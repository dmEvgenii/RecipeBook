using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.Domain.Class;

namespace WebApplication1.Controllers.Presentation.Models
{
    public class StartModel
    {
        public string name { get; set; }
        public string Description { get; set; }


        public StartModel(Start inst)
        {
            name = inst?.Name2 ?? throw new ArgumentNullException(nameof(inst.Name2));
            Description = inst?.Description ?? throw new ArgumentNullException(nameof(inst.Description));

        }
        // Пустой конструктор для работы
        public StartModel()
        {

        }


        public Start ToClass()
        {

           
                return new Start()
                {
                    Description = this.Description,
                    Name2 = this.name
                };
            
        }
    }
    
}
