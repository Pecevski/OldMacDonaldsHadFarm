using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Entities
{
    public class Cat : Animal
    {
        public override string Name => "Cat";

        public override string Sound => "Meow";

        public override void SingVerse()
        {
        }
    }
}
