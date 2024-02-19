using Polymorphic_Approach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Presentation
{
    public class InputOutputProvider : IInputOutputProvider
    {

        public void PrintToOutput(string message)
        {
            Console.WriteLine(message);
        }
        public string GetFromInput()
        {
            return Console.ReadLine();
        }
    }
}
