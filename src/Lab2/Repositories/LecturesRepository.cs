using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LecturesRepository : IRepository<Lecture>
{
    private readonly List<IEntity> _lectures = new();

    public void Add(Lecture entity)
    {
        _lectures.Add(entity);
    }

    public Lecture? SearchId(int id)
    {
        foreach (Lecture lecture in _lectures)
        {
            if (lecture.Id == id) return lecture;
        }

        return null;
    }
}