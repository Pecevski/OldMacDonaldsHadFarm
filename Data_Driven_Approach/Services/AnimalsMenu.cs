using Data_Driven_Approach.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Services
{
    public class AnimalsMenu
    {
        private readonly IInputOutputProvider _ioProvider;
        private readonly AnimalServices _animalServices;

        public AnimalsMenu(IInputOutputProvider ioProvider, AnimalServices animalServices)
        {
            _ioProvider = ioProvider;
            _animalServices = animalServices;
        }

        public void ShowAnimalsMenu()
        {
            while (true)
            {
                _ioProvider.PrintToOutput("Animals Menu:");
                _ioProvider.PrintToOutput("1. PrintAllAnimals");
                _ioProvider.PrintToOutput("2. Choose from existing animals");
                _ioProvider.PrintToOutput("3. Add animal");
                _ioProvider.PrintToOutput("4. Exit");
                _ioProvider.PrintToOutput("Enter your choice: ");

                string input = _ioProvider.GetFromInput();

                switch (input)
                {
                    case "1":
                        _animalServices.PrintAllAnimal();
                        break;
                    case "2":
                        _animalServices.ChooseAnimal();
                        break;
                    case "3":
                        _animalServices.AddAnimal();
                        break;
                    case "4":
                        return;
                    default:
                        _ioProvider.PrintToOutput("Invalid choice. Please try again.");
                        break;
                }

            }

        }

        public void SingVerseForAnimal(Animal animal)
        {
            _ioProvider.PrintToOutput(VerseGenerator.GetVerseForAnimal(animal)); ;
        }
    }
}
