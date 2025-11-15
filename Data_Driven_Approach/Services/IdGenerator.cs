using Data_Driven_Approach.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Services
{
    public class IdGenerator
    {
        private readonly IAnimalContext _animalContext;

        public IdGenerator(IAnimalContext animalContext)
        {
            _animalContext = animalContext;  
        }
        public int GenerateNewId() 
        { 
            int newId = 1;

            if (_animalContext.Animals.Any())
            {
                newId = _animalContext.Animals.Max(x => x.Id) + 1;
            }
            return newId;
        }
    }
}
