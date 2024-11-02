using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LabWorkRepository : IRepository<LabWork>
{
    public Collection<IEntity> LabWorks { get; } = new();

    public void Add(LabWork entity)
    {
        LabWorks.Add(entity);
    }

    public LabWork? SearchId(Guid id)
    {
        foreach (IEntity entity in LabWorks)
        {
            var labWork = (LabWork)entity;
            if (labWork.Id == id) return labWork;
        }

        return null;
    }
}