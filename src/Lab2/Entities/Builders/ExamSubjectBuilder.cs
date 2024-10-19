using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using ArgumentException = System.ArgumentException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class ExamSubjectBuilder
{
    private int _id;
    private string? _name;
    private User? _author;
    private int _examPoints;
    private int _basedOnId = 0;

    public ExamSubjectBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public ExamSubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ExamSubjectBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public ExamSubjectBuilder SetExamPoints(int points)
    {
        _examPoints = points;
        return this;
    }

    public ExamSubjectBuilder SetBasedOnId(int id)
    {
        _basedOnId = id;
        return this;
    }

    public ExamSubject Build()
    {
        if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

        if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

        if (_basedOnId != 0) return new ExamSubject(_id, _name, _author, _examPoints, _basedOnId);

        return new ExamSubject(_id, _name, _author, _examPoints);
    }
}