// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
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
List<ContainerShip> containerShips = new List<ContainerShip>();
List<Container> containers = new List<Container>();
string? input;




do
{
    Console.Out.WriteLine("Options: \n" +
                          "q - quit \n" +
                          "1 - Create ContainerShip\n" +
                          "2 - Create Container\n" +
                          "3 - Load Container to ship\n" +
                          "4 - Load to the container\n" +
                          "5 - Unload from container\n" +
                          "6 - Unload container\n" +
                          "7 - change temperature\n" +
                          "8 - container info\n" +
                          "9 - Ship info");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
        {
            Console.Out.WriteLine("enter Max Speed");
            int maxSpeed = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("enter Max Containers count");
            int maxContainers = Convert.ToInt32(Console.ReadLine());
            Console.Out.WriteLine("enter Load in tones");
            double maxLoad = Convert.ToDouble(Console.ReadLine());
            if (maxSpeed > 0 && maxContainers > 0 && maxLoad > 0)
            {
                containerShips.Add(new ContainerShip(maxSpeed, maxContainers, maxLoad));
            }
            else
            {
                Console.Out.WriteLine("Values must be biger than 0");
            }
        }
            break;
        case "2":
        {
            Console.Out.WriteLine("Select type of the container: \n" +
                                  "1 - Gaz\n" +
                                  "2 - Liquid\n" +
                                  "3 - Liquid Hazard\n" +
                                  "4 - Refrigerated");

            int type = Convert.ToInt32(Console.ReadLine());
            if (type <= 4 && type >= 1)
            {
                Console.Out.WriteLine("Enter height: ");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.Out.WriteLine("Enter ownWeight: ");
                double ownWeight = Convert.ToDouble(Console.ReadLine());
                Console.Out.WriteLine("Enter depth: ");
                double depth = Convert.ToDouble(Console.ReadLine());
                Console.Out.WriteLine("Enter maxLoad: ");
                double maxLoad = Convert.ToDouble(Console.ReadLine());
                if (height <= 0 && ownWeight <= 0 && depth <= 0 && maxLoad <= 0)
                {
                    Console.Out.WriteLine("Values must be bigger than 0");
                }
                else
                {
                    switch (type)
                    {
                        case 1:
                            containers.Add(new GazContainer(height, ownWeight, depth, maxLoad));
                            break;
                        case 2:
                            containers.Add(new LiquidConainter(height, ownWeight, depth, maxLoad));
                            break;
                        case 3:
                            containers.Add(new LiquidContainerHazard(height, ownWeight, depth, maxLoad));
                            break;
                        case 4:
                            containers.Add(new RefrigeratedContainer(height, ownWeight, depth, maxLoad));
                            break;
                    }
                }

            }
        }
            break;
        case "3":
        {
            for (int i = 0; i < containers.Count; i++)
            {
                Console.Out.WriteLine(i + " - " + containers[i]);
            }

            Console.Out.WriteLine("Select container");
            int selection = Convert.ToInt32(Console.ReadLine());
            
             for (int i = 0; i < containerShips.Count; i++)
            {
                Console.Out.WriteLine(i + " - " + containerShips[i]);
            }

            Console.Out.WriteLine("Select Ship");
            int shipSelection = Convert.ToInt32(Console.ReadLine());
            
            
            if (selection > 0 && selection <= containers.Count)
            {
                if (shipSelection > 0 && shipSelection <= containerShips.Count)
                {
                    containerShips[shipSelection].Load(containers[selection]);
                }
            }

        }
            break;
        case "4":
        {
            for (int i = 0; i < containers.Count; i++)
            {
                Console.Out.WriteLine(i + " - " + containers[i]);
            }

            Console.Out.WriteLine("Select container");
            int selection = Convert.ToInt32(Console.ReadLine());
            
            if (selection >= 0 && selection <= containers.Count)
            {
                if (containers[selection].type != "RefrigeratedContainer")
                {
                    
                    Console.Out.WriteLine("Enter weight of the load");
                    double weight = Convert.ToDouble(Console.ReadLine());
                    containers[selection].Load(weight);
                }
                else
                {
                    Console.Out.WriteLine("Enter weight of the load");
                    double weight = Convert.ToDouble(Console.ReadLine());
                    int tmp = 0;
                    String[] enums = Enum.GetNames(typeof(Products));

                    foreach (String pro in enums)
                    {
                        Console.Out.WriteLine(tmp+ " " + pro);
                        tmp++;
                    }
                    Console.Out.WriteLine("Select Type of the product");
                    int type = Convert.ToInt32(Console.ReadLine());
                    
                    RefrigeratedContainer refrigeratedContainer = (RefrigeratedContainer)containers[selection];
                    refrigeratedContainer.Load(weight,(Products)Enum.Parse(typeof(Products),enums[type]));

                }

            }
            
            
        }
            break;
    }
} while (input != "q");