using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

public class TestSubject : Subject
{
    public TestSubject(int id, string name, User user, int points) : base(id, name, user)
    {
        TestPoints = points;
    }

    public TestSubject(int id, string name, User user, int points, int basedOnId) : base(id, name, user, basedOnId)
    {
        TestPoints = points;
    }

    public override Subject Clone()
    {
        return new TestSubject(Id, Name, Author, TestPoints, BasedOnId == 0 ? Id : BasedOnId);
    }

    public int TestPoints { get; private set; }

    private Collection<IEntity> _labworks = new();

    public OperationResult SetExamPoints(int newTestPoints, User user)
    {
        if (user.Id == Author.Id)
        {
            if (newTestPoints > 0 && newTestPoints < 100)
            {
                TestPoints = newTestPoints;
                return new OperationResult.Success();
            }

            return new OperationResult.PointsFault();
        }

        return new OperationResult.AuthorFault();
    }

    public override OperationResult SetLabWorks(Collection<IEntity> labwork)
    {
        int pointSum = 0;
        foreach (IEntity entity2 in _labworks)
        {
            var entity1 = (LabWork)entity2;
            pointSum += entity1.Points;
        }

        if (pointSum != 100) return new OperationResult.PointsFault();
        _labworks = labwork;
        return new OperationResult.Success();
    }

    public override OperationResult AddLabWorks(LabWork labwork)
    {
        int pointSum = labwork.Points;
        foreach (IEntity entity2 in _labworks)
        {
            var entity1 = (LabWork)entity2;
            pointSum += entity1.Points;
        }

        if (pointSum != 100) return new OperationResult.PointsFault();
        _labworks.Add(labwork);
        return new OperationResult.Success();
    }
}