using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class LectureBuilder
{
    private int _id;
    private string? _name;
    private User? _author;
    private string? _description;
    private string? _data;
    private int _basedOnId;

    public LectureBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public LectureBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LectureBuilder SetAuthor(User user)
    {
        _author = user;
        return this;
    }

    public LectureBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureBuilder SetData(string data)
    {
       _data = data;
       return this;
    }

    public LectureBuilder SetBasedOnId(int points)
    {
        _basedOnId = points;
        return this;
    }

    public Lecture Build()
    {
        if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

        if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

        if (_description == null) throw new ArgumentException("Description cannot be null.", nameof(_description));

        if (_data == null) throw new ArgumentException("EvaluationCriteria cannot be null.", nameof(_data));

        if (_basedOnId != 0) return new Lecture(_id, _name, _author, _description, _data, _basedOnId);
        return new Lecture(_id, _name, _author, _description, _data);
    }
}