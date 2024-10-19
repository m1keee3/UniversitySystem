using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class StudyProgramm : IEntity
{
    public int Id { get; }

    public string Name { get; private set; }

    public User Leader { get; }

    private readonly List<Semestr> _semestrs = new();

    public StudyProgramm(int id, string name, User user)
    {
        Id = id;
        Name = name;
        Leader = user;
    }

    public OperationResult AddSemestr(Collection<Subject> subjects, User user)
    {
        if (user.Id == Leader.Id)
        {
            _semestrs.Add(new Semestr(subjects));
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult AddSubject(Subject subject, int semestrNum, User user)
    {
        if (user.Id == Leader.Id)
        {
            _semestrs[semestrNum].AddSubject(subject);
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    private class Semestr
    {
        private readonly Collection<Subject> _subjects;

        public Semestr(Collection<Subject> subjects)
        {
            _subjects = subjects;
        }

        public void AddSubject(Subject subject)
        {
            _subjects.Add(subject);
        }
    }
}