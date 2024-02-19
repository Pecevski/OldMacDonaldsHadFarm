using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Entities
{
    public class Dog : Animal
    {
        public override string Name => "Dog";

        public override string Sound => "Av";

        public override void SingVerse()
        {
        }
    }
}
