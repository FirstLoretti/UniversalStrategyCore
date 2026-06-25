using System.Runtime.CompilerServices;

namespace UniversalStrategyCore.Shared;

public record Error(string Id, string Message)
{
    public static Error NotEnoughtResource(GameResourceType resource)
        => new("not_enought_resource", $"Не хватает: {resource}");

    public static Error AlreadyExist<T>(T entityId, string collectionName) where T : struct
        => AlreadyExistInternal(entityId, collectionName);

    public static Error NotFound<T>(T entityId, string collectionName) where T : struct
        => NotFoundInternal(entityId, collectionName);

    private static string BuildAlredyExistMessage(string className, string entityId, string collectionName)
        => $"[{className}] {entityId} уже содержится в {collectionName}";

    private static string BuildNotFoundMessage(string className, string entityId, string collectionName)
        => $"[{className}] {entityId} не содержится в {collectionName}";

    private static Error NotFoundInternal<T>(
        T entityId, string collectionName, [CallerFilePath] string path = ""
    ) where T : struct
    {
        var className = Path.GetFileNameWithoutExtension(path);
        var id = $"{entityId.ToString}";
        return new Error(
            $"{entityId}_not_found",
            BuildNotFoundMessage(className, id, collectionName)
        );
    }

    private static Error AlreadyExistInternal<T>(
        T entityId, string collectionName, [CallerFilePath] string path = ""
    ) where T : struct
    {
        var className = Path.GetFileNameWithoutExtension(path);
        var id = $"{entityId.ToString}";
        return new Error(
            $"{entityId}_already_exist",
            BuildAlredyExistMessage(className, id, collectionName)
        );
    }
}