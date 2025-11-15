using Newtonsoft.Json;
using Polymorphic_Approach.Entities;
using Polymorphic_Approach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonException = Newtonsoft.Json.JsonException;

namespace Polymorphic_Approach.Services
{
    public class AnimalServices
    {
        private readonly IInputOutputProvider _ioProvider;
        private List<Animal> animals = new List<Animal>
        {
            new Cat(),
            new Cow(),
            new Dog(),
            new Pig(),
            new Duck()
        };

        public AnimalServices(IInputOutputProvider ioProvider)
        {
            _ioProvider = ioProvider;
        }

        public void PrintAllAnimal()
        {

            if (animals == null || animals.Count == 0)
            {
                _ioProvider.PrintToOutput("No animals to print.");
                return;
            }

            int idCounter = 1;
            foreach (var animal in animals)
            {
                if(animal.Id == 0)
                {
                    animal.Id = GenerateNewId();
                }
                _ioProvider.PrintToOutput($"ID: {animal.Id}, Name: {animal.Name}, Sound: {animal.Sound}");
                idCounter++;
            }
        }
        public void ChooseAnimal()
        {
            while (true)
            {
                _ioProvider.PrintToOutput("Choose an Animal from the list OR choose ZERO to return back to Menu: ");
                string input = _ioProvider.GetFromInput().CheckNullOrEmpty();
                int choice = input.ValidatePositiveInteger();
                if (choice == 0)
                {
                    break;
                }
                var animal = GetAnimalById(choice);
                if (animal == null)
                {
                    _ioProvider.PrintToOutput($"Animal with id {choice} does not exist");
                    continue;
                }
                string verse = VerseGenerator.GetVerseForAnimal(animal);
                _ioProvider.PrintToOutput(verse);
            }
        }

        private Animal? GetAnimalById(int id)
        {
            return id <= animals.Count ? animals[id - 1] : null;
        }

        public int GenerateNewId()
        {
            int newId = 1;

            if(animals.Any())
            {
                newId = animals.Max(x => x.Id) + 1;
            }
            return newId;
        }

    }
}
