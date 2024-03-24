namespace Zad3.Models;

public class LiquidContainerHazard : LiquidConainter, IHazardNotifier
{
    
    
    public LiquidContainerHazard(double height, double ownWeight, double depth, double maxLoad)
        : base(height, ownWeight, depth, maxLoad)
    {
        type = "LiquidContainerHazard";
        SerialNumber = "KON-L-"+ (Counter++);
    }
    
    private void Hazard(string rejNum)
    {
        Console.Out.WriteLine("HAZARD: You must leave 50% empty in container: "+rejNum);
    }

    public void Load(double weight)
    {
        if (Loaded + weight <= MaxLoad*0.5)
        {
            Loaded += weight;
            Console.Out.WriteLine("Container Loaded");
        }
        else
        {
            Hazard(SerialNumber);
        }
    }
    public override string ToString()
    {
        return base.ToString()+"\n" +
               "Load: Hazard Liquid";
    }

}