using Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.InfoTrain.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Models;

public class MagneticRoad : IRouteSegment
{
    private readonly double _length;

    public MagneticRoad(double length)
    {
        if (length <= 0) throw new ArgumentException("maxIncomingSpeed must be greater than 0", nameof(length));
        _length = length;
    }

    public RouteResult Passing(Train train)
    {
        return train.RunRoad(_length);
    }
}