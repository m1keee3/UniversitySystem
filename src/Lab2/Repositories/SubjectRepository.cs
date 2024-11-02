using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class SubjectRepository : IRepository<Subject>
{
    private readonly List<Subject> _lectures = new();

    public void Add(Subject entity)
    {
        _lectures.Add(entity);
    }

    public Subject? SearchId(Guid id)
    {
        foreach (Subject lecture in _lectures)
        {
            if (lecture.Id == id) return lecture;
        }

        return null;
    }
}