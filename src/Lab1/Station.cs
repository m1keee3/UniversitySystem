namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station(double maxIncomingSpeed, double loadingTime) : RouteSegment
{
    private double MaxIncomingSpeed { get; } = maxIncomingSpeed;

    private double LoadingTime { get; } = loadingTime;

    public override RouteResult Passing(Train train)
    {
        return train.SpeedCheck(MaxIncomingSpeed) ?
            new RouteResult(true, LoadingTime) : new RouteResult(false, 0);
    }
}