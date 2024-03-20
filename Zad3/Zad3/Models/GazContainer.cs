﻿namespace Zad3.Models;

public class GazContainer : Container, IHazardNotifier
{
    public double pressure { get; set; }
    private static int counter = 1;
    public GazContainer( double height, double ownWeight, double depth, double maxLoad)
        : base( height, ownWeight, depth, maxLoad)
    {
        SerialNumber = "KON-G-" + counter++;
        pressure = 0;
    }

    private void Hazard(string rejNum)
    {
        Console.Out.WriteLine("HAZARD: you must leave 5% of the load in container: "+rejNum);
    }
    
    public void unload(double weight)
    {
        if (this.Loaded*1.05 >= weight)
        {
            Loaded = Loaded - weight;
            pressure -= weight / 100;
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
        }
        else
        {
            throw new OverfillException("OVERLOAD");
        }
    }
    
    
}