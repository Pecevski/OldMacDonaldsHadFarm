using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Entities
{
    public abstract class Animal
    {
        [Required]
        [Length(1, 20)]
        public abstract string Name { get; }

        [Required]
        [Length(1, 20)]
        public abstract string Sound { get; }
        public abstract void SingVerse();

    }
}
