namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route(double speedLimit)
{
    private readonly List<RouteSegment> _sections = new();

    private double SpeedLimit { get; } = speedLimit;

    public void AddSection(RouteSegment section)
    {
        _sections.Add(section);
    }

    public RouteResult Simulate(Train train)
    {
        double timeSum = 0;

        foreach (RouteSegment section in _sections)
        {
            RouteResult result = section.Passing(train);
            if (!result.Success) return new RouteResult(false, 0);

            timeSum += result.Time;
        }

        return train.SpeedCheck(SpeedLimit) ?
            new RouteResult(true, timeSum) : new RouteResult(false, 0);
    }
}