using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

public class ExamSubject : Subject
{
    public int ExamPoints { get; private set; }

    private Collection<IEntity> _labworks = new();

    public ExamSubject(int id, string name, User user, int examPoints) : base(id, name, user)
    {
        ExamPoints = examPoints;
    }

    public ExamSubject(int id, string name, User user, int examPoints, int basedOnId) : base(id, name, user, basedOnId)
    {
        ExamPoints = examPoints;
    }

    public override Subject Clone()
    {
        return new ExamSubject(Id, Name, Author, ExamPoints, BasedOnId == 0 ? Id : BasedOnId);
    }

    public OperationResult SetExamPoints(int points, User user)
    {
        if (user.Id == Author.Id)
        {
            if (points > 0 && points < 100)
            {
                ExamPoints = points;
                return new OperationResult.Success();
            }

            return new OperationResult.PointsFault();
        }

        return new OperationResult.AuthorFault();
    }

    public override OperationResult SetLabWorks(Collection<IEntity> labwork)
    {
        int pointSum = ExamPoints;
        foreach (IEntity entity2 in labwork)
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
        int pointSum = labwork.Points + ExamPoints;
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