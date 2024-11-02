namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPrototype<T> where T : IPrototype<T>
{
    T Clone();
}