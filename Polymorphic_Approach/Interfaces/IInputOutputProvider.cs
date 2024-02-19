using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Interfaces
{
    public interface IInputOutputProvider
    {
        public void PrintToOutput(string message);
        public string GetFromInput();
    }
}
