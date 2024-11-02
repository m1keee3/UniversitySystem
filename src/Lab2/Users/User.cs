namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public User(int id, string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}