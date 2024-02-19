using Polymorphic_Approach.Presentation;
using Polymorphic_Approach.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var ioprovider = new InputOutputProvider();
        var services = new AnimalServices(ioprovider);
        AnimalsMenu menu = new AnimalsMenu(ioprovider, services);
        menu.ShowAnimalsMenu();
    }
}