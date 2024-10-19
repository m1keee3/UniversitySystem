namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
{
    public void Add(T entity);

    public T? SearchId(int id);
}