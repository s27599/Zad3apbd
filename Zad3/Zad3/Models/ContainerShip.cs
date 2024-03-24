using System.Collections;
using System.Text;
using Zad3.Models.@base;

namespace Zad3.Models;

public class ContainerShip
{
    public String RejNumber { get; }
    public List<Container> containers { get; }
    public int maxSpeed { get; }
    public int maxContainers { get; }
    public double maxContainerMass { get; }
    private double _ContainerMass;
    private static int counter = 1;

    public ContainerShip(int maxSpeed, int maxContainers, double maxContainerMass)
    {
        this.RejNumber = "SHIP-" + counter++;
        this.containers = new List<Container>();
        this.maxSpeed = maxSpeed;
        this.maxContainers = maxContainers;
        this.maxContainerMass = maxContainerMass;
        Console.Out.WriteLine("Ship Created");
    }

    public void Load(Container container)
    {
        if (IsLoaded(container))
        {
            Console.Out.WriteLine("Container is already Loaded");
        }
        else
        {
            if (containers.Count < maxContainers)
            {
                if (maxContainerMass > (container.OwnWeight + container.Loaded) + _ContainerMass)
                {
                    containers.Add(container);
                    container.OnShip = true;
                    _ContainerMass = (container.OwnWeight + container.Loaded) + _ContainerMass;
                    Console.Out.WriteLine("Container Loaded");
                }
                else
                {
                    Console.Out.WriteLine("This container is to heavy");
                }
            }
            else
            {
                Console.Out.WriteLine("This ship has to many containers loaded");
            }
        }
    }

    public void Load(List<Container> containersToLoad)
    {
        double sumMas = 0;

        if (containers.Any(x => containersToLoad.Any(y => y == x)))
        {
            Console.Out.WriteLine("Some containers From this list are already Loaded");
        }
        else
        {
            foreach (Container con in containersToLoad)
            {
                sumMas += (con.OwnWeight + con.Loaded);
            }
            if (containers.Count + containersToLoad.Count < maxContainers)
            {
                if (maxContainerMass > sumMas + _ContainerMass)
                {
                    foreach (Container con in containersToLoad)
                    {
                        containers.Add(con);
                        con.OnShip = true;
                        Console.Out.WriteLine("Container Loaded");
                    }
                    _ContainerMass = sumMas + _ContainerMass;
                }
            }
        }
    }


    public void unload(Container container)
    {
        if (containers.Contains(container))
        {
            containers.Remove(container);
            _ContainerMass -= (container.OwnWeight + container.Loaded);
            container.OnShip = false;
            Console.Out.WriteLine("Container Unloaded");
        }
    }


    public bool IsLoaded(Container container)
    {
        return containers.Contains(container);
    }

    public void ChangeContainer(Container container1, Container container2)
    {
        if (!IsLoaded(container1))
        {
            Console.Out.WriteLine("Container1 is not loaded on this ship");
        }
        else
        {
            unload(container1);
            Load(container2);
            Console.Out.WriteLine("Containers Changed");
        }
    }

    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Container con in containers)
        {
            sb.Append(con);
            sb.Append("\n ");
        }

        return "ContainerShip: " + RejNumber + "\n" +
               "Transporting: " + _ContainerMass + "t \n" +
               "Containers: " + sb.ToString();

    }




}