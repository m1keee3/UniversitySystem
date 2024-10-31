using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

public class TestSubject : Subject
{
    private TestSubject(int id, string name, User user, int points) : base(id, name, user)
    {
        TestPoints = points;
    }

    private TestSubject(int id, string name, User user, int points, int basedOnId) : base(id, name, user, basedOnId)
    {
        TestPoints = points;
    }

    public override Subject Clone()
    {
        return new TestSubject(Id, Name, Author, TestPoints, BasedOnId == 0 ? Id : BasedOnId);
    }

    public int TestPoints { get; private set; }

    private LabWorkRepository _labworks = new();

    public OperationResult SetTestPoints(int newTestPoints, User user)
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

    public override OperationResult SetLabWorks(LabWorkRepository labwork)
    {
        int pointSum = 0;
        foreach (IEntity entity2 in _labworks.LabWorks)
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
        foreach (IEntity entity2 in _labworks.LabWorks)
        {
            var entity1 = (LabWork)entity2;
            pointSum += entity1.Points;
        }

        if (pointSum != 100) return new OperationResult.PointsFault();
        _labworks.Add(labwork);
        return new OperationResult.Success();
    }

    public class TestSubjectBuilder
    {
        private int _id;
        private string? _name;
        private User? _author;
        private int _testPoints;
        private int _basedOnId = 0;

        public TestSubjectBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        public TestSubjectBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public TestSubjectBuilder SetAuthor(User user)
        {
            _author = user;
            return this;
        }

        public TestSubjectBuilder SetExamPoints(int points)
        {
            _testPoints = points;
            return this;
        }

        public TestSubjectBuilder SetBasedOnId(int id)
        {
            _basedOnId = id;
            return this;
        }

        public TestSubject Build()
        {
            if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

            if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

            if (_basedOnId != 0) return new TestSubject(_id, _name, _author, _testPoints, _basedOnId);

            return new TestSubject(_id, _name, _author, _testPoints);
        }
    }
}