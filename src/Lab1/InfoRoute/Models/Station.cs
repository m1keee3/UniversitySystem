using Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.InfoTrain.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Models;

public class Station : IRouteSegment
{
    private readonly double _maxIncomingSpeed;

    private readonly double _loadingTime;

    public Station(double maxIncomingSpeed, double loadingTime)
    {
        if (maxIncomingSpeed <= 0) throw new ArgumentException("maxIncomingSpeed must be greater than 0", nameof(maxIncomingSpeed));
        if (loadingTime < 0) throw new ArgumentException("loadingTime cannot be negative", nameof(loadingTime));
        _maxIncomingSpeed = maxIncomingSpeed;
        _loadingTime = loadingTime;
    }

    public RouteResult Passing(Train train)
    {
        return (train.Speed <= _maxIncomingSpeed) ?
            new RouteResult(true, _loadingTime) : new RouteResult(false, 0);
    }
}