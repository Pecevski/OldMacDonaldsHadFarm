using Data_Driven_Approach.Data;
using Data_Driven_Approach.Presentation;
using Data_Driven_Approach.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var ioprovider = new InputOutputProvider();
        var context = new AnimalContext(ioprovider);
        var services = new AnimalServices(context, ioprovider);
        AnimalsMenu menu = new AnimalsMenu(ioprovider, services);
        menu.ShowAnimalsMenu();
    }
}