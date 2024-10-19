using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class TestSubjectFactory : ISubjectFactory
{
    public Subject CreateSubject(int id, string name, User author, int points, int basedOnId = 0)
    {
        ExamSubjectBuilder builder = new ExamSubjectBuilder()
            .SetId(id)
            .SetName(name)
            .SetAuthor(author)
            .SetExamPoints(points)
            .SetBasedOnId(basedOnId);

        return builder.Build();
    }
}