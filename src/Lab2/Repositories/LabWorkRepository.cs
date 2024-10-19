using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LabWorkRepository : IRepository<LabWork>
{
    private readonly List<IEntity> labWorks = new();

    public void Add(LabWork entity)
    {
        labWorks.Add(entity);
    }

    public LabWork? SearchId(int id)
    {
        foreach (LabWork labWork in labWorks)
        {
            if (labWork.Id == id) return labWork;
        }

        return null;
    }
}