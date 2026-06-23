namespace UniversalStrategyCore.Shared;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public Error? Error { get; }

    public static Result<T> SuccessInfo(T value) => new(true, value, null);
    public static Result<T> Failure(Error error) => new(false, default, error);
    public static implicit operator Result<T>(T value) => SuccessInfo(value);
    public static implicit operator Result<T>(Error error) => Failure(error);

    private Result(bool isSuccess, T? value, Error? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }
}