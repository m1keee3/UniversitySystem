namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record Success() : OperationResult;

    public sealed record AuthorFault() : OperationResult;

    public sealed record PointsFault() : OperationResult;
}