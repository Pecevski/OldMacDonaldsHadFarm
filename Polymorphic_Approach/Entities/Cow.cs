using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Entities
{
    public class Cow : Animal
    {
        public override string Name => "Cow";

        public override string Sound => "Moo";

        public override void SingVerse()
        {
        }
    }
}
