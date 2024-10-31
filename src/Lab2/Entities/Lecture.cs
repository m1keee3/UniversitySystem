using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Lecture : IEntity
{
    public int Id { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public string Description { get; private set; }

    public string Data { get; private set; }

    public int BasedOnId { get; } = 0;

    private Lecture(int id, string name, User user, string description, string data)
    {
        Id = id;
        Name = name;
        Author = user;
        Description = description;
        Data = data;
    }

    private Lecture(int id, string name, User user, string description, string data, int basedOnId)
    {
        Id = id;
        Name = name;
        Author = user;
        Description = description;
        Data = data;
        BasedOnId = basedOnId;
    }

    public Lecture Clone()
    {
        return new Lecture(Id, Name, Author, Description, Data, BasedOnId == 0 ? Id : BasedOnId);
    }

    public OperationResult SetName(string newName, User user)
    {
        if (user.Id == Author.Id)
        {
            Name = newName;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult SetDescription(string newDescription, User user)
    {
        if (user.Id == Author.Id)
        {
            Description = newDescription;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public OperationResult SetData(string newData, User user)
    {
        if (user.Id == Author.Id)
        {
            Data = newData;
            return new OperationResult.Success();
        }

        return new OperationResult.AuthorFault();
    }

    public class LectureBuilder
    {
        private int _id;
        private string? _name;
        private User? _author;
        private string? _description;
        private string? _data;
        private int _basedOnId;

        public LectureBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        public LectureBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public LectureBuilder SetAuthor(User user)
        {
            _author = user;
            return this;
        }

        public LectureBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public LectureBuilder SetData(string data)
        {
           _data = data;
           return this;
        }

        public LectureBuilder SetBasedOnId(int points)
        {
            _basedOnId = points;
            return this;
        }

        public Lecture Build()
        {
            if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

            if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

            if (_description == null) throw new ArgumentException("Description cannot be null.", nameof(_description));

            if (_data == null) throw new ArgumentException("EvaluationCriteria cannot be null.", nameof(_data));

            if (_basedOnId != 0) return new Lecture(_id, _name, _author, _description, _data, _basedOnId);
            return new Lecture(_id, _name, _author, _description, _data);
        }
    }
}