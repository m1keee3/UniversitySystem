namespace Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;

public abstract record RouteResult
{
    private RouteResult() { }

    public sealed record Success(double Time) : RouteResult;

    public sealed record StationSpeedLimitFail() : RouteResult;

    public sealed record RouteSpeedLimitFail() : RouteResult;

    public sealed record NotEnoughPower() : RouteResult;
}