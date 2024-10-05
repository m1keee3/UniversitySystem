using Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.InfoRoute.Models;
using Itmo.ObjectOrientedProgramming.Lab1.InfoTrain.Entities;
using Xunit;

namespace Lab1.Tests;

public class AllTests
{
    [Fact]
    public void ShouldPassRoute_WhenRouteLimitAcceptable_ReturnsTrainPassResultSuccess()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 50);

        route.AddSection(new PowerMagneticRoad(length: 150, force: 1000));
        route.AddSection(new MagneticRoad(length: 500));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void ShouldPassRoute_WhenRouteLimitNotAcceptable_ReturnsTrainPassResultFailure()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 50);

        route.AddSection(new PowerMagneticRoad(length: 210, force: 1000));
        route.AddSection(new MagneticRoad(length: 600));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.RouteSpeedLimitFail>(result);
    }

    [Fact]
    public void ShouldPassRoute_WhenStationAndRouteLimitAcceptable_ReturnsTrainPassResultSucces()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 100);

        route.AddSection(new PowerMagneticRoad(length: 550, force: 1000));
        route.AddSection(new MagneticRoad(length: 200));
        route.AddSection(new Station(maxIncomingSpeed: 100, loadingTime: 10));
        route.AddSection(new MagneticRoad(length: 300));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void ShouldFailStationLimit_WhenStationLimitNotAcceptable_ReturnsTrainPassResultFailure()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 100);

        route.AddSection(new PowerMagneticRoad(length: 550, force: 1000));
        route.AddSection(new MagneticRoad(length: 200));
        route.AddSection(new Station(maxIncomingSpeed: 90, loadingTime: 10));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.StationSpeedLimitFail>(result);
    }

    [Fact]
    public void ShouldPassStationAndFailRouteLimit_WhenStationLimitAcceptableAndRouteLimitNotAcceptable_ReturnsTrainPassResultFailure()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 90);

        route.AddSection(new PowerMagneticRoad(length: 550, force: 1000));
        route.AddSection(new MagneticRoad(length: 200));
        route.AddSection(new Station(maxIncomingSpeed: 100, loadingTime: 10));
        route.AddSection(new MagneticRoad(length: 300));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.RouteSpeedLimitFail>(result);
    }

    [Fact]
    public void ShouldPassStationAndRouteLimit_WhenSpeedAboveLimitButSlowsDownToAcceptableSpeed_ReturnsTrainPassResultSucces()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 50);

        route.AddSection(new PowerMagneticRoad(length: 550, force: 1000));
        route.AddSection(new MagneticRoad(length: 200));
        route.AddSection(new PowerMagneticRoad(length: 50, force: -5000));
        route.AddSection(new Station(maxIncomingSpeed: 50, loadingTime: 10));
        route.AddSection(new MagneticRoad(length: 200));
        route.AddSection(new PowerMagneticRoad(length: 130, force: 1000));
        route.AddSection(new MagneticRoad(length: 300));
        route.AddSection(new PowerMagneticRoad(length: 50, force: -2000));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void ShouldFailMagneticRoad_WhenSpeedIsZero_ReturnsTrainPassResultFailure()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 50);

        route.AddSection(new MagneticRoad(length: 100));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.NotEnoughPower>(result);
    }

    [Fact]
    public void ShouldFailPowerMagneticRoad_WhenSpeedIsNotTooEnoughToPassSlowingDownPowerMagneticRoad_ReturnsTrainPassResultFailure()
    {
        var train = new Train(weight: 100, maxForce: 2000, accuracy: 1);
        var route = new Route(speedLimit: 50);

        route.AddSection(new PowerMagneticRoad(length: 550, force: 1000));
        route.AddSection(new PowerMagneticRoad(length: 550, force: -2000));

        RouteResult result = route.Simulate(train);

        Assert.IsType<RouteResult.NotEnoughPower>(result);
    }
}
