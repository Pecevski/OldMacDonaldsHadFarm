using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Data
{
    public class Animal : BaseEntity
    {
        [Required]
        [Length(1, 20)]
        public string Name { get; set; }

        [Required]
        [Length(1, 20)]
        public string Sound { get; set; }
    }
}
