using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

public abstract class Subject
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public Guid? BasedOnId { get; }

    private LecturesRepository _lectures = new();

    protected Subject(string name, User user, Guid? basedOnId = null)
    {
        Id = Guid.NewGuid();
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
}