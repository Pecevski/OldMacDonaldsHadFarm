using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Services
{
    public interface IInputOutputProvider
    {
        public void PrintToOutput(string message);
        public string GetFromInput();
    }
}
