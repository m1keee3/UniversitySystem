using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class LabWork : IEntity
{
    public int Id { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public string Description { get; private set; }

    public string EvaluationCriteria { get; private set; }

    public int Points { get; private set; }

    public int BasedOnId { get; } = 0;

    public LabWork(int id, string name, User user, string description, string evaluationCriteria, int points)
    {
        Id = id;
        Name = name;
        Author = user;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
    }

    public LabWork(int id, string name, User user, string description, string evaluationCriteria, int points, int basedOnId)
    {
        Id = id;
        Name = name;
        Author = user;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
        BasedOnId = basedOnId;
    }

    public LabWork Clone()
    {
        return new LabWork(Id, Name, Author, Description, EvaluationCriteria, Points, BasedOnId == 0 ? Id : BasedOnId);
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

    public OperationResult SetEvaluationCriteria(string newEvaluationCriteria, User user)
    {
        if (user.Id == Author.Id)
        {
            EvaluationCriteria = newEvaluationCriteria;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult SetPoints(int newPoints, User user)
    {
        if (user.Id == Author.Id)
        {
            Points = newPoints;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }
}
