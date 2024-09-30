namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PowerMagneticRoad(double length, double force) : RouteSegment
{
    private double Length { get; } = length;

    private double Force { get; } = force;

    public override RouteResult Passing(Train train)
    {
        train.ApplyForce(Force);
        return train.RunRoad(Length);
    }
}