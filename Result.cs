namespace UniversalStrategyCore;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public ErrorType? ErrorType { get; }

    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(ErrorType errorType) => new(false, default, errorType);
    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(ErrorType errorType) => Failure(errorType);

    private Result(bool isSuccess, T? value, ErrorType? errorType)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorType = errorType;
    }
}