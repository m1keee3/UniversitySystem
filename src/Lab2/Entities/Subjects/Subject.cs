using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

public abstract class Subject
{
    public int Id { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public int BasedOnId { get; } = 0;

    private LecturesRepository _lectures = new();

    protected Subject(int id, string name, User user)
    {
        Id = id;
        Name = name;
        Author = user;
    }

    protected Subject(int id, string name, User user, int basedOnId)
    {
        Id = id;
        Name = name;
        Author = user;
        BasedOnId = basedOnId;
    }

    public abstract OperationResult SetLabWorks(LabWorkRepository labwork);

    public abstract OperationResult AddLabWorks(LabWork labwork);

    public OperationResult SetName(string newName, User user)
    {
        if (user.Id == Author.Id)
        {
            Name = newName;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult SetLectures(LecturesRepository newLectures, User user)
    {
        if (user.Id == Author.Id)
        {
            _lectures = newLectures;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult AddLecture(Lecture newLecture)
    {
        _lectures.Add(newLecture);
        return new OperationResult.Success();
    }

    public abstract Subject Clone();
}