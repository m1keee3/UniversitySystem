using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class TestSubjectFactory : ISubjectFactory
{
    public Subject CreateSubject(int id, string name, User author, int points, int basedOnId = 0)
    {
        ExamSubject.ExamSubjectBuilder builder = new ExamSubject.ExamSubjectBuilder()
            .SetId(id)
            .SetName(name)
            .SetAuthor(author)
            .SetExamPoints(points)
            .SetBasedOnId(basedOnId);

        return builder.Build();
    }
}