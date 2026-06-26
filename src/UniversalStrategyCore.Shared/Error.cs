using System.Runtime.CompilerServices;

namespace UniversalStrategyCore.Shared;

public record Error(string Message)
{
    public static Error NotEnoughtResource(GameResourceType resource)
        => new($"Не хватает: {resource}");

    public static Error AlreadyExist<T>(T entityId, string collectionName, [CallerFilePath] string path = "") where T : struct
        => new(BuildAlredyExistMessage(Path.GetFileNameWithoutExtension(path), $"{entityId}", collectionName));

    public static Error NotFound<T>(T entityId, string collectionName, [CallerFilePath] string path = "") where T : struct
        => new(BuildNotFoundMessage(Path.GetFileNameWithoutExtension(path), $"{entityId}", collectionName));

    private static string BuildAlredyExistMessage(string className, string entityId, string collectionName)
        => $"[{className}] {entityId} уже содержится в {collectionName}";

    private static string BuildNotFoundMessage(string className, string entityId, string collectionName)
        => $"[{className}] {entityId} не содержится в {collectionName}";
}