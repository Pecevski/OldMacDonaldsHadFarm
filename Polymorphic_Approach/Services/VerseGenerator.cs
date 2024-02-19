using Polymorphic_Approach.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphic_Approach.Services
{
    public class VerseGenerator
    {
        public static string GetVerseForAnimal(Animal animal)
        {
            return $"Old MacDonald had a farm, E-I-E-I-O," + "\n" +
            $"And on his farm he had a {animal.Name}, E-I-E-I-O," + "\n" +
            $"With a {animal.Sound} {animal.Sound} here and a {animal.Sound} {animal.Sound} there," + "\n" +
            $"Here a {animal.Sound}, there a {animal.Sound}, everywhere a {animal.Sound} {animal.Sound}," + "\n" +
            $"Old MacDonald had a farm, E-I-E-I-O.\n" + "\n";
        }
    }
}
