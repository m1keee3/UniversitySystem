using Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.InfoTrain.Entities;

public class Train
{
    public double Speed { get; private set; }

    private readonly double _weight;

    private readonly double _accuracy;

    private readonly double _maxForce;

    private double _boost;

    public Train(double weight, double maxForce, double accuracy)
    {
        if (weight < 0) throw new ArgumentException("Weight cannot be negative", nameof(weight));
        if (_maxForce < 0) throw new ArgumentException("MaxForce cannot be negative", nameof(maxForce));
        if (accuracy < 0) throw new ArgumentException("Accuracy cannot be negative", nameof(accuracy));

        Speed = 0;
        _boost = 0;
        _weight = weight;
        _maxForce = maxForce;
        _accuracy = accuracy;
    }

    public RouteResult RunRoad(double length)
    {
        double time = 0;
        if (_boost == 0 && Speed == 0) return new RouteResult(false, 0);
        while (length > 0 && Speed >= 0)
        {
            Speed += _boost * _accuracy;
            length -= Speed * _accuracy;
            time += _accuracy;
        }

        _boost = 0;
        return Speed >= 0 ?
            new RouteResult(true, time) : new RouteResult(false, 0);
    }

    public bool ApplyForce(double force)
    {
        if (force > _maxForce)
        {
            return false;
        }

        _boost += force / _weight;
        return true;
    }
}