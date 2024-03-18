namespace Zad3;

public abstract class Container
{
    protected int Load { get; set; }
    protected int Height { get; }
    protected int OwnWeight{ get; }
    protected int Depth{ get; }
    protected String SerialNumber{ get; set; }
    protected int MaxLoad{ get; }

    protected Container(int load, int height, int ownWeight, int depth, int maxLoad)
    {
        this.Load = load;
        this.Height = height;
        this.OwnWeight = ownWeight;
        this.Depth = depth;
        this.MaxLoad = maxLoad;
    }

    protected void Unload(int weight)
    {
        if (this.Load >= weight)
        {
            Load = Load - weight;
        }
        else
        {
            Console.Out.WriteLine("W kontenerze nie ma tyle ładunku");
        }
    }

    protected void load(int weight)
    {
        if (Load + weight <= MaxLoad)
        {
            Load += weight;
        }
        else
        {
            throw new OverfillException("Przeładowanie");
        }
    }
}

public class OverfillException : Exception
{
    public OverfillException(){}
    public OverfillException(string message):base(message){}
}

