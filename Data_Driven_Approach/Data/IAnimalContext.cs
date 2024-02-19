using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Data
{
    public interface IAnimalContext
    {
        List<Animal> Animals { get; }

        void SaveChanges();
    }
}
