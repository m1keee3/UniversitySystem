using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LecturesRepository : IRepository<Lecture>
{
    public Collection<IEntity> Lectures { get; } = new();

    public void Add(Lecture entity)
    {
        Lectures.Add(entity);
    }

    public Lecture? SearchId(int id)
    {
        foreach (IEntity entity in Lectures)
        {
            var lecture = (Lecture)entity;
            if (lecture.Id == id) return lecture;
        }

        return null;
    }
}