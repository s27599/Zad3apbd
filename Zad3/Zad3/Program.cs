// See https://aka.ms/new-console-template for more information

using Zad3.Models;
using Zad3.Models.@base;

// Console.WriteLine("Hello, World!");
//
//
// RefrigeratedContainer container = new RefrigeratedContainer(12,14,54,211);
// container.Temp = 20;
// container.Load(12,Products.Bananas);
// Console.Out.WriteLine(container.Loaded+" "+ container.Products);
// container.Load(12,Products.Butter);
// container.Temp = 12;
//
// GazContainer gazContainer = new GazContainer(12, 2, 45, 125);
// gazContainer.Load(123);
//
// List<Container> containers = new List<Container>();
// containers.Add(container);
// containers.Add(gazContainer);
//
// Console.Out.WriteLine(container);
//
// ContainerShip containerShip = new ContainerShip(12, 123, 123123);
// containerShip.Load(container);
// Console.Out.WriteLine("");
// Console.Out.WriteLine(containerShip);
//
// containerShip.Load(containers);
//
// Console.Out.WriteLine(containerShip);


string? input;
do
{
     Console.Out.WriteLine("Options: \n" +
                           "q - quit \n" +
                           "1-Create ContainerShip");
     input = Console.ReadLine();
} while (input != "q");


