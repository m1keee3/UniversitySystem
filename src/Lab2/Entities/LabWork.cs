using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class LabWork : IEntity, IPrototype<LabWork>
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public string Description { get; private set; }

    public string EvaluationCriteria { get; private set; }

    public int Points { get; private set; }

    public Guid? BasedOnId { get; }

    private LabWork(string name, User user, string description, string evaluationCriteria, int points, Guid? basedOnId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Author = user;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
        BasedOnId = basedOnId;
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

    public class LabWorkBuilder
    {
        private string? _name;
        private User? _author;
        private string? _description;
        private string? _evaluationCriteria;
        private int _points;
        private Guid? _basedOnId;

        public LabWorkBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public LabWorkBuilder SetAuthor(User user)
        {
            _author = user;
            return this;
        }

        public LabWorkBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public LabWorkBuilder SetEvaluationCriteria(string evaluationCriteria)
        {
            _evaluationCriteria = evaluationCriteria;
            return this;
        }

        public LabWorkBuilder SetPoints(int points)
        {
            _points = points;
            return this;
        }

        public LabWorkBuilder SetBasedOnId(Guid basedOnId)
        {
            _basedOnId = basedOnId;
            return this;
        }

        public LabWork Build()
        {
            if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

            if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

            if (_description == null) throw new ArgumentException("Description cannot be null.", nameof(_description));

            if (_evaluationCriteria == null) throw new ArgumentException("EvaluationCriteria cannot be null.", nameof(_evaluationCriteria));

            return new LabWork(_name, _author, _description, _evaluationCriteria, _points, _basedOnId);
        }
    }

    public LabWork Clone()
    {
        return new LabWork(Name, Author, Description, EvaluationCriteria, Points, Id);
    }
}
