using Data_Driven_Approach.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Presentation
{
    public class InputOutputProvider : IInputOutputProvider
    {
        public string GetFromInput()
        {
            return Console.ReadLine();
        }

        public void PrintToOutput(string message)
        {
            Console.WriteLine(message);
        }
    }
}
