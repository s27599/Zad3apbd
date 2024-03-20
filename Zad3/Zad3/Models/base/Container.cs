namespace Zad3;

public abstract class Container
{
    protected double Loaded { get; set; }
    protected double Height { get; }
    protected double OwnWeight{ get; }
    protected double Depth{ get; }
    protected String SerialNumber{ get; set; }
    protected double MaxLoad{ get; }

    protected Container( double height, double ownWeight, double depth, double maxLoad)
    {
        this.Loaded = 0;
        this.Height = height;
        this.OwnWeight = ownWeight;
        this.Depth = depth;
        this.MaxLoad = maxLoad;
    }

    public void Unload(double weight)
    {
        if (this.Loaded >= weight)
        {
            Loaded = Loaded - weight;
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
        }
        else
        {
            throw new OverfillException("OVERLOAD");
        }
    }
}

public class OverfillException : Exception
{
    public OverfillException(){}
    public OverfillException(string message):base(message){}
}

