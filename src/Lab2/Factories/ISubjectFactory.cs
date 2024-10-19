using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public interface ISubjectFactory
{
    public Subject CreateSubject(int id, string name, User author, int points, int basedOnId = 0);
}