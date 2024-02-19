using Data_Driven_Approach.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Services
{
    public static class Validations
    {
        public static int ValidatePositiveInteger(this string input)
        {
            var result = int.TryParse(input, out int parsed);

            if (!result || parsed < 0)
            {
                throw new InputException("Invalid Input");
            }

            return parsed;
        }

        public static string CheckNullOrEmpty(this string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new InputException("Invalid input");
            }

            return input;
        }
    }
}
