using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using ArgumentException = System.ArgumentException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class TestSubjectBuilder
{
    private int _id;
    private string? _name;
    private User? _author;
    private int _testPoints;
    private int _basedOnId = 0;

    public TestSubjectBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public TestSubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public TestSubjectBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public TestSubjectBuilder SetExamPoints(int points)
    {
        _testPoints = points;
        return this;
    }

    public TestSubjectBuilder SetBasedOnId(int id)
    {
        _basedOnId = id;
        return this;
    }

    public TestSubject Build()
    {
        if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

        if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

        if (_basedOnId != 0) return new TestSubject(_id, _name, _author, _testPoints, _basedOnId);

        return new TestSubject(_id, _name, _author, _testPoints);
    }
}