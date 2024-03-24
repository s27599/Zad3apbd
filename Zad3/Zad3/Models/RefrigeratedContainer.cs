using Zad3.Models.@base;

namespace Zad3.Models;

public class RefrigeratedContainer : Container
{
    public Products? Products { get; private set; }
    private double _temp;
    private static int counter = 1;
    public RefrigeratedContainer(double height, double ownWeight, double depth, double maxLoad, Products products)
        : base(height, ownWeight, depth, maxLoad)
    {
        SerialNumber = "KON-C-" + counter++;
        
        this.Products = products;
        _temp = ((int)Products) / 100;
    }

    public RefrigeratedContainer(double height, double ownWeight, double depth, double maxLoad)
        : base(height, ownWeight, depth, maxLoad)
    {
        SerialNumber = "KON-L" + counter++;

        Products = null;
        _temp = 20;
    }

    public void Load(double x)
    {
        Console.Out.WriteLine("Specify product Category");
    }


    public void Load(double weight, Products category)
    {
        if ((Products == null || Products == category) && Temp >= (((int)category) / 100))
        {
            if (Loaded + weight <= MaxLoad)
            {
                Loaded += weight;
                Products = category;
                _temp = ((int)Products) / 100;
            }
            else
            {
                throw new OverfillException("OVERLOAD");
            }
        }
        else
        {
            Console.Out.WriteLine("Check Container temp or Products Loaded");
            // Console.Out.WriteLine(_temp+ " "+ Products  );
        }
    }

    public void Unload(double weight)
    {
        if (this.Loaded >= weight)
        {
            Loaded = Loaded - weight;
            if (Loaded == 0)
            {
                Products = null;
            }
        }
        else
        {
            Console.Out.WriteLine("Container don't have that much Load");
        }
    }


    public double Temp
    {
        get => _temp;
        set
        {
            if (!Products.HasValue)
            {
                _temp = value;
            }
            else if (value >= ((int)Products / 100))

            {
                _temp = value;
            }
            else
            {
                Console.Out.WriteLine("You cant change temperature: Load would freeze");
            }
        }
    }


    public override string ToString()
    {
        return base.ToString()+"\n" +
               "Load: "+Products+" \n" +
               "Temperature:" +_temp;
    }

}