using Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.InfoTrain.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Models;

public class PowerMagneticRoad : IRouteSegment
{
    private readonly double _length;

    private readonly double _force;

    public PowerMagneticRoad(double length, double force)
    {
        if (length <= 0) throw new ArgumentException("maxIncomingSpeed must be greater than 0", nameof(length));
        _length = length;
        _force = force;
    }

    public RouteResult Passing(Train train)
    {
        train.ApplyForce(_force);
        return train.RunRoad(_length);
    }
}