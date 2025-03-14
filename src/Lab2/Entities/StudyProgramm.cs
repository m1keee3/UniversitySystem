﻿using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class StudyProgramm : IEntity
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public User Leader { get; }

    private readonly List<Semestr> _semestrs = new();

    public StudyProgramm(int id, string name, User user)
    {
        Id = Guid.NewGuid();
        Name = name;
        Leader = user;
    }

    public OperationResult SetName(string newName, User user)
    {
        if (user.Id == Leader.Id)
        {
            Name = newName;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public Semestr GetSemestr(int semNum)
    {
        return _semestrs[semNum];
    }

    public OperationResult AddSemestr(SubjectRepository subjects, User user)
    {
        if (user.Id == Leader.Id)
        {
            _semestrs.Add(new Semestr(subjects)); // Creator
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

    public class Semestr
    {
        private readonly SubjectRepository _subjects;

        public Semestr(SubjectRepository subjects)
        {
            _subjects = subjects;
        }

        public void AddSubject(Subject subject)
        {
            _subjects.Add(subject);
        }
    }
}