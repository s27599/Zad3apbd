namespace Zad3.Models.@base;

public abstract class Container
{
    public double Loaded { get; protected set; }
    public double Height { get; }
    public double OwnWeight{ get; }
    public double Depth{ get; }
    public String SerialNumber{ get; protected set; }
    public double MaxLoad{ get; }
    public String type { get; protected set; }
    public bool OnShip { get;  set; }

    protected Container( double height, double ownWeight, double depth, double maxLoad)
    {
        this.Loaded = 0;
        this.Height = height;
        this.OwnWeight = ownWeight;
        this.Depth = depth;
        this.MaxLoad = maxLoad;
        Console.Out.WriteLine("Container Created");
    }

    public void Unload(double weight)
    {
        if (this.Loaded >= weight)
        {
            Loaded = Loaded - weight;
            Console.Out.WriteLine("Container unloaded");
        }
        else
        {
            Console.Out.WriteLine("Container don't have that much Load");
        }
    }

    public void Load(double weight)
    {
        if (Loaded + weight <= MaxLoad)
        {
            Loaded += weight;
            Console.Out.WriteLine("Container loaded");
        }
        else
        {
            throw new OverfillException("OVERLOAD");
        }
    }

    public override string ToString()
    {
        return "Container: " + SerialNumber + "\n" +
               "Loaded: " + Loaded +"t";


    }



}



public class OverfillException : Exception
{
    public OverfillException(){}
    public OverfillException(string message):base(message){}
}



