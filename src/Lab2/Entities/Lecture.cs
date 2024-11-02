using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Lecture : IEntity, IPrototype<Lecture>
{
    public Guid? Id { get; }

    public string Name { get; private set; }

    public User Author { get; }

    public string Description { get; private set; }

    public string Data { get; private set; }

    public Guid? BasedOnId { get; }

    private Lecture(string name, User user, string description, string data, Guid? basedOnId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Author = user;
        Description = description;
        Data = data;
        BasedOnId = basedOnId;
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
        private string? _name;
        private User? _author;
        private string? _description;
        private string? _data;
        private Guid? _basedOnId;

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

        public LectureBuilder SetBasedOnId(Guid? id)
        {
            _basedOnId = id;
            return this;
        }

        public Lecture Build()
        {
            if (_name == null) throw new ArgumentException("Name cannot be null.", nameof(_name));

            if (_author == null) throw new ArgumentException("Author cannot be null.", nameof(_author));

            if (_description == null) throw new ArgumentException("Description cannot be null.", nameof(_description));

            if (_data == null) throw new ArgumentException("EvaluationCriteria cannot be null.", nameof(_data));

            return new Lecture(_name, _author, _description, _data, _basedOnId);
        }
    }

    public Lecture Clone()
    {
        return new Lecture(Name, Author, Description, Data, Id);
    }
}