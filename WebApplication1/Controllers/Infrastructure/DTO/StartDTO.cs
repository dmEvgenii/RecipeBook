using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.Domain.Class;


namespace WebApplication1.Controllers.Infrastructure.DTO
{
    public class StartDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string ingredients { get; set; }

        public string note { get; set; }



        public Start ToModel()
        {
            return new Start()
            {
                Name2 = name,
                Description = description
            };

        }


        public Start_Put ToModelPut()
        {


            
                return new Start_Put()
                {
                    Name1 = name,
                    Ingredients = ingredients,
                    Note = note
                };
            
        }

    
    }


    
}
