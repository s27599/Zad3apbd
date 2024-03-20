using Zad3.Models.@base;

namespace Zad3.Models;

public class LiquidConainter : Container, IHazardNotifier
{
    protected static int Counter = 1;
    
    public LiquidConainter( double height, double ownWeight, double depth, double maxLoad)
        : base( height, ownWeight, depth, maxLoad)
    {
        SerialNumber = "KON-L-" + Counter++;
    }

    private void Hazard(string rejNum)
    {
        Console.Out.WriteLine("HAZARD: You must leave 10% empty in container: "+rejNum);
    }

    public void Load(double weight)
    {
        if (Loaded + weight <= MaxLoad*0.9)
        {
            Loaded += weight;
        }
        else
        {
           Hazard(SerialNumber);
        }
    }
    
    
}