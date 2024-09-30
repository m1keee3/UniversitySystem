namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train(double weight, double maxForce, double accuracy)
{
    private double Speed { get; set; } = 0;

    private double Weight { get; } = weight;

    private double Accuracy { get; } = accuracy;

    private double MaxForce { get; } = maxForce;

    private double Boost { get; set; } = 0;

    public RouteResult RunRoad(double length)
    {
        double time = 0;
        if (Boost == 0 && Speed == 0) return new RouteResult(false, 0);
        while (length > 0 && Speed >= 0)
        {
            Speed += Boost * Accuracy;
            length -= Speed * Accuracy;
            time += Accuracy;
        }

        Boost = 0;
        return Speed >= 0 ?
            new RouteResult(true, time) : new RouteResult(false, 0);
    }

    public bool ApplyForce(double force)
    {
        if (force > MaxForce)
        {
            return false;
        }

        Boost += force / Weight;
        return true;
    }

    public bool SpeedCheck(double speedLimit)
    {
        return Speed <= speedLimit;
    }
}