using Data_Driven_Approach.Data;


namespace Data_Driven_Approach.Services
{
    public class AnimalServices
    {
        private readonly IAnimalContext _animalContext;
        private readonly IInputOutputProvider _ioProvider;
        private readonly IdGenerator _idGenerator;

        public AnimalServices(IAnimalContext animalContext, IInputOutputProvider ioProvider, IdGenerator idGenerator)
        {
            _animalContext = animalContext;
            _ioProvider = ioProvider;
            _idGenerator = idGenerator;

        }
        public void PrintAllAnimal()
        {
            if (_animalContext == null || _animalContext.Animals.Count == 0)
            {
                _ioProvider.PrintToOutput("No animals to print.");
                return;
            }

            int counterId = 1;
            foreach (var animal in _animalContext.Animals)
            {
                if (animal.Id == 0)
                {
                    animal.Id = _idGenerator.GenerateNewId();
                }
                _ioProvider.PrintToOutput($"ID: {animal.Id}, Name: {animal.Name}, Sound: {animal.Sound}");
                counterId++;
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
           return id <= _animalContext.Animals.Count ? _animalContext.Animals[id - 1] : null;
        }

        public void AddAnimal()
        {
            Console.Write("Enter the name of the new animal: ");
            string name = _ioProvider.GetFromInput().CheckNullOrEmpty();

            if (_animalContext.Animals.Any(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                _ioProvider.PrintToOutput($"An animal with the name '{name}' already exists. Please choose a different animal name.");
                return;
            }

            Console.Write("Enter the sound of the new animal: ");
            string sound = _ioProvider.GetFromInput().CheckNullOrEmpty();

            int animalId = _idGenerator.GenerateNewId();

            Animal newAnimal = new Animal {Id = animalId, Name = name, Sound = sound };
            _animalContext.Animals.Add(newAnimal);

            _ioProvider.PrintToOutput($"New animal '{name}' with sound '{sound}' added successfully!");

            _animalContext.SaveChanges();
        }
    }
}
