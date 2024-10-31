using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

public class ExamSubject : Subject
{
    public int ExamPoints { get; private set; }

    private LabWorkRepository _labworks = new();

    private ExamSubject(int id, string name, User user, int examPoints) : base(id, name, user)
    {
        ExamPoints = examPoints;
    }

    private ExamSubject(int id, string name, User user, int examPoints, int basedOnId) : base(id, name, user, basedOnId)
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

    public override OperationResult SetLabWorks(LabWorkRepository labwork)
    {
        int pointSum = ExamPoints;
        foreach (IEntity entity2 in labwork.LabWorks)
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
        foreach (IEntity entity2 in _labworks.LabWorks)
        {
            var entity1 = (LabWork)entity2;
            pointSum += entity1.Points;
        }

        if (pointSum != 100) return new OperationResult.PointsFault();
        _labworks.Add(labwork);
        return new OperationResult.Success();
    }

    public class ExamSubjectBuilder
    {
        private int _id;
        private string? _name;
        private User? _author;
        private int _examPoints;
        private int _basedOnId = 0;

        public ExamSubjectBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        public ExamSubjectBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ExamSubjectBuilder SetAuthor(User user)
        {
            _author = user;
            return this;
        }

        public ExamSubjectBuilder SetExamPoints(int points)
        {
            _examPoints = points;
            return this;
        }

        public ExamSubjectBuilder SetBasedOnId(int id)
        {
            _basedOnId = id;
            return this;
        }

        public ExamSubject Build()
        {
            if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

            if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

            if (_basedOnId != 0) return new ExamSubject(_id, _name, _author, _examPoints, _basedOnId);

            return new ExamSubject(_id, _name, _author, _examPoints);
        }
    }
}