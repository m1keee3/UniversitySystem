using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class AllTests
{
    [Fact]
    public void TruingChangeLabWorkByNotAuthor_ShouldReturnAuthorFault()
    {
        var user1 = new User(1, "Mike");
        var user2 = new User(2, "Not Mike");
        var labBuilder = new LabWorkBuilder();
        labBuilder.SetId(1).SetName("lab1").SetAuthor(user1).SetDescription(" ").SetEvaluationCriteria(" ").SetPoints(10);
        LabWork labWork = labBuilder.Build();

        OperationResult result1 = labWork.SetName("0_0", user2);
        OperationResult result2 = labWork.SetDescription("0_0", user2);
        OperationResult result3 = labWork.SetEvaluationCriteria("0_0", user2);
        OperationResult result4 = labWork.SetPoints(0, user2);

        Assert.IsType<OperationResult.AuthorFault>(result1);
        Assert.IsType<OperationResult.AuthorFault>(result2);
        Assert.IsType<OperationResult.AuthorFault>(result3);
        Assert.IsType<OperationResult.AuthorFault>(result4);
    }

    [Fact]
    public void TruingChangeLectureByNotAuthor_ShouldReturnAuthorFault()
    {
        var user1 = new User(1, "Mike");
        var user2 = new User(2, "Not Mike");
        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetId(1).SetName("lab1").SetAuthor(user1).SetDescription(" ").SetData(" ").SetBasedOnId(10);
        Lecture lecture = lectureBuilder.Build();

        OperationResult result1 = lecture.SetName("0_0", user2);
        OperationResult result2 = lecture.SetDescription("0_0", user2);
        OperationResult result3 = lecture.SetData("0_0", user2);

        Assert.IsType<OperationResult.AuthorFault>(result1);
        Assert.IsType<OperationResult.AuthorFault>(result2);
        Assert.IsType<OperationResult.AuthorFault>(result3);
    }

    [Fact]
    public void TruingChangeExamSubjectByNotAuthor_ShouldReturnAuthorFault()
    {
        var user1 = new User(1, "Mike");
        var user2 = new User(2, "Not Mike");
        var examSubjectFactory = new ExamSubjectFactory();
        Subject math = examSubjectFactory.CreateSubject(1, "Math", user1, 100);

        OperationResult result1 = math.SetName("0_0", user2);

        Assert.IsType<OperationResult.AuthorFault>(result1);
    }

    [Fact]
    public void CopyingLabWork_ShouldBeEqualBasedOnIdOfCopyAndOriginId()
    {
        var user1 = new User(1, "Mike");
        var user2 = new User(2, "Not Mike");
        var labBuilder = new LabWorkBuilder();
        labBuilder.SetId(1).SetName("lab1").SetAuthor(user1).SetDescription(" ").SetEvaluationCriteria(" ").SetPoints(10);
        LabWork labWork = labBuilder.Build();
        LabWork labWorkCopy = labWork.Clone();

        Assert.True(labWorkCopy.BasedOnId == labWork.Id);
    }

    [Fact]
    public void CopyingLectureWork_ShouldBeEqualBasedOnIdOfCopyAndOriginId()
    {
        var user1 = new User(1, "Mike");
        var user2 = new User(2, "Not Mike");
        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetId(1).SetName("lab1").SetAuthor(user1).SetDescription(" ").SetData(" ");
        Lecture lecture = lectureBuilder.Build();
        Lecture lectureCopy = lecture.Clone();

        Assert.True(lectureCopy.BasedOnId == lecture.Id);
    }

    [Fact]
    public void CopyingExamSubjectFactoryWork_ShouldBeEqualBasedOnIdOfCopyAndOriginId()
    {
        var user1 = new User(1, "Mike");
        var user2 = new User(2, "Not Mike");
        var examSubjectFactory = new ExamSubjectFactory();
        Subject math = examSubjectFactory.CreateSubject(1, "Math", user1, 100);
        Subject mathCopy = math.Clone();

        Assert.True(mathCopy.BasedOnId == math.Id);
    }

    [Fact]
    public void CopyingTestSubjectFactoryWork_ShouldBeEqualBasedOnIdOfCopyAndOriginId()
    {
        var user1 = new User(1, "Mike");
        var user2 = new User(2, "Not Mike");
        var testSubjectFactory = new TestSubjectFactory();
        Subject math = testSubjectFactory.CreateSubject(1, "Math", user1, 60);
        Subject mathCopy = math.Clone();

        Assert.True(mathCopy.BasedOnId == math.Id);
    }

    [Fact]
    public void AddLabworkSoPointsAreOver100_ShouldReturnPointsFault()
    {
        var user1 = new User(1, "Mike");
        var examSubjectFactory = new ExamSubjectFactory();
        Subject math = examSubjectFactory.CreateSubject(1, "Math", user1, 100);
        var labBuilder = new LabWorkBuilder();
        labBuilder.SetId(1).SetName("lab1").SetAuthor(user1).SetDescription(" ").SetEvaluationCriteria(" ").SetPoints(10);
        LabWork labWork = labBuilder.Build();

        OperationResult result = math.AddLabWorks(labWork);

        Assert.IsType<OperationResult.PointsFault>(result);
    }
}