namespace Itmo.ObjectOrientedProgramming.Lab1;

public class MagneticRoad(double length) : RouteSegment
{
    private double Length { get; } = length;

    public override RouteResult Passing(Train train)
    {
        return train.RunRoad(Length);
    }
}