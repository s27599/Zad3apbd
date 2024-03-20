using Zad3.Models;

namespace Zad3;

public class LiquidContainerHazard : LiquidConainter, IHazardNotifier
{
    public LiquidContainerHazard(int height, int ownWeight, int depth, int maxLoad)
        : base(height, ownWeight, depth, maxLoad)
    {
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
        }
        else
        {
            Hazard(SerialNumber);
        }
    }
    
    
}