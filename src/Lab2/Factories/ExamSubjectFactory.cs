using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class ExamSubjectFactory : ISubjectFactory
{
    public Subject CreateSubject(int id, string name, User author, int points, Guid? basedOnId = null)
    {
        ExamSubject.ExamSubjectBuilder builder = new ExamSubject.ExamSubjectBuilder()
            .SetName(name)
            .SetAuthor(author)
            .SetExamPoints(points)
            .SetBasedOnId(basedOnId);

        return builder.Build();
    }
}