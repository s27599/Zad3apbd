using Zad3.Models.@base;

namespace Zad3.Models;

public class GazContainer : Container, IHazardNotifier
{
    public double pressure { get; set; }
    private static int counter = 1;
    public GazContainer( double height, double ownWeight, double depth, double maxLoad)
        : base( height, ownWeight, depth, maxLoad)
    {
        type = "GazContainer";
        SerialNumber = "KON-G-" + counter++;
        pressure = 0;
    }

    private void Hazard(string rejNum)
    {
        Console.Out.WriteLine("HAZARD: you must leave 5% of the load in container: "+rejNum);
    }
    
    public void Unload(double weight)
    {
        if (this.Loaded*1.05 >= weight)
        {
            Loaded = Loaded - weight;
            pressure -= weight / 100;
            Console.Out.WriteLine("Container Unloaded");
        }
        else
        {
            Hazard(SerialNumber);
        }
    }
    
    public void Load(double weight)
    {
        if (Loaded + weight <= MaxLoad)
        {
            Loaded += weight;
            pressure += weight/100;
            Console.Out.WriteLine("Container Loaded");
        }
        else
        {
            throw new OverfillException("OVERLOAD");
        }
    }

    public override string ToString()
    {
        return base.ToString() + "\n" +
               "Load: Gaz \n" +
               "Preasure: " + pressure;
    }


}