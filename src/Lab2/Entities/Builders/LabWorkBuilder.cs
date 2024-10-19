using Itmo.ObjectOrientedProgramming.Lab2.Users;
using ArgumentException = System.ArgumentException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class LabWorkBuilder
{
    private int _id;
    private string? _name;
    private User? _author;
    private string? _description;
    private string? _evaluationCriteria;
    private int _points;
    private int _basedOnId = 0;

    public LabWorkBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

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

    public LabWorkBuilder SetBasedOnId(int basedOnId)
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

        if (_basedOnId != 0) return new LabWork(_id, _name, _author, _description, _evaluationCriteria, _points, _basedOnId);

        return new LabWork(_id, _name, _author, _description, _evaluationCriteria, _points);
    }
}