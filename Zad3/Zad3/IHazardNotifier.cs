namespace Zad3;

public interface IHazardNotifier
{
    public void Hazard(String message, String rejNum)
    {
        Console.Out.WriteLine("HAZARD: "+message + "on container: "+rejNum);
    }


}