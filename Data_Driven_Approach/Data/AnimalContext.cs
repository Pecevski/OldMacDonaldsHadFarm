using Data_Driven_Approach.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data_Driven_Approach.Data
{
    public class AnimalContext : IAnimalContext
    {
        private List<Animal> _animals;
        private readonly IInputOutputProvider _ioProvider;
        public List<Animal> Animals
        {
            get
            {
                return _animals ??= GetAllAnimals();
            }
        }

        public AnimalContext(IInputOutputProvider ioProvider)
        {
            _ioProvider = ioProvider;   
        }
        public void SaveChanges()
        {

            string jsonString = JsonSerializer.Serialize(_animals);

            string relativePath = @"animals.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectRoot, relativePath);
           
            //string filePath = @"C:\Users\Ilija\source\repos\OldMacDonaldsHadFarm\Data_Driven_Approach\animals.json";
            File.WriteAllText(filePath, jsonString);
            _ioProvider.PrintToOutput("Animal is saved to JSON document."); 
        }

        private List<Animal> GetAllAnimals()
        {
            string relativePath = @"animals.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectRoot, relativePath);

            //string path = @"C:\Users\Ilija\source\repos\OldMacDonaldsHadFarm\Data_Driven_Approach\animals.json";
            try
            {
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    var data = JsonSerializer.Deserialize<List<Animal>>(jsonString);

                    return data;
                }
                else
                {
                   _ioProvider.PrintToOutput("File does not exist at the specified path.");
                }
            }
            catch (JsonException ex)
            {
                _ioProvider.PrintToOutput($"An error occurred while deserializing the JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                _ioProvider.PrintToOutput($"An error occurred: {ex.Message}");
            }

            return new List<Animal>();
        }
    }
}
