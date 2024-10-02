namespace Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;

public class RouteResult(bool success, double time)
{
    public bool Success { get; } = success;

    public double Time { get; } = time;
}