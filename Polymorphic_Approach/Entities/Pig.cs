using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Entities
{
    public class Pig : Animal
    {
        public override string Name => "Pig";

        public override string Sound => "Oink";

        public override void SingVerse()
        {
        }
    }
}
