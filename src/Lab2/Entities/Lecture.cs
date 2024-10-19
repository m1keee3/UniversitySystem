using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Lecture : IEntity
{
    public int Id { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public string Description { get; private set; }

    public string Data { get; private set; }

    public int BasedOnId { get; } = 0;

    public Lecture(int id, string name, User user, string description, string data)
    {
        Id = id;
        Name = name;
        Author = user;
        Description = description;
        Data = data;
    }

    public Lecture(int id, string name, User user, string description, string data, int basedOnId)
    {
        Id = id;
        Name = name;
        Author = user;
        Description = description;
        Data = data;
        BasedOnId = basedOnId;
    }

    public Lecture Clone()
    {
        return new Lecture(Id, Name, Author, Description, Data, BasedOnId == 0 ? Id : BasedOnId);
    }

    public OperationResult SetName(string newName, User user)
    {
        if (user.Id == Author.Id)
        {
            Name = newName;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult SetDescription(string newDescription, User user)
    {
        if (user.Id == Author.Id)
        {
            Description = newDescription;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult SetData(string newData, User user)
    {
        if (user.Id == Author.Id)
        {
            Data = newData;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }
}