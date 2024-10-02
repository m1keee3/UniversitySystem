using Itmo.ObjectOrientedProgramming.Lab1.InfoTrain.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;

public interface IRouteSegment
{
    public RouteResult Passing(Train train);
}
