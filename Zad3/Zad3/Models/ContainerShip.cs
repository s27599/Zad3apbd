using System.Collections;
using Zad3.Models.@base;

namespace Zad3.Models;

public class ContainerShip
{
    public List<Container> containers { get; }
    public int maxSpeed { get; }
    public int maxContainers { get; }
    public double maxContainerMass { get; }
    private double _ContainerMass;

    public ContainerShip( int maxSpeed, int maxContainers, double maxContainerMass)
    {
        this.containers = new List<Container>();
        this.maxSpeed = maxSpeed;
        this.maxContainers = maxContainers;
        this.maxContainerMass = maxContainerMass;
    }

    public void Load(Container container)
    {
        if (containers.Count < maxContainers)
        {
            if (maxContainerMass > (container.OwnWeight + container.Loaded) + _ContainerMass)
            {
                containers.Add(container);
                _ContainerMass = (container.OwnWeight + container.Loaded) + _ContainerMass;
            }
        }
    }

    public void Load(List<Container> containersToLoad)
    {
        double sumMas = 0;
        
        // policzyć łączną masę i porównywać z max masą łączną
        foreach (Container con in containersToLoad)
        {
            sumMas += (con.OwnWeight + con.Loaded);
        }
        if (containers.Count+containersToLoad.Count < maxContainers)
        {
            if (maxContainerMass > sumMas + _ContainerMass)
            {
                foreach (Container con in containersToLoad) containers.Add(con);

                _ContainerMass = sumMas + _ContainerMass;
            }
        }
        
    }
    

    public void unload(Container container)
    {
        if (containers.Contains(container))
        {
            containers.Remove(container);
            _ContainerMass -= (container.OwnWeight + container.Loaded) ;
        }
    }
    
    
    
}