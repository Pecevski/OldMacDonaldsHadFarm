using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Entities
{
    public class Duck : Animal
    {
        public override string Name => "Duck";

        public override string Sound => "Quac";

        public override void SingVerse()
        {
        }
    }
}
