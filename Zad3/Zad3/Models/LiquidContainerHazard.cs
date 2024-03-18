using Zad3.Models;

namespace Zad3;

public class LiquidContainerHazard : LiquidConainter, IHazardNotifier
{
    public LiquidContainerHazard(int load, int height, int ownWeight, int depth, int maxLoad)
        : base(load, height, ownWeight, depth, maxLoad*0.5)
    {
        SerialNumber = "KON-L-"+ (Counter++);
    }
}