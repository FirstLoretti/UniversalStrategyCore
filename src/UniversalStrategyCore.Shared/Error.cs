using System.Runtime.CompilerServices;

namespace UniversalStrategyCore.Shared;

public record Error(string Id, string Messange)
{
    public static Error PlayerIdAlredyExist(PlayerId player)
        => new($"{player}_already_exist", $"Игрок с именем: {player} уже существует");

    public static Error NotEnoughtResource(GameResourceType resource)
        => new("not_enought_resource", $"Не хватает: {resource}");

    public static Error NotFound<T>(T entytyId, string collectionName) where T : struct
        => NotFoundInternal(entytyId, collectionName);

    private static string BuildMessage(string className, string entityId, string collectionName)
        => $"[{className}] {entityId} не содержится в {collectionName}";

    private static Error NotFoundInternal<T>(T entytyId, string collectionName, [CallerFilePath] string path = "") where T : struct
    {
        var className = Path.GetFileNameWithoutExtension(path);
        var id = $"{entytyId.ToString}";
        return new Error(
            $"{entytyId}_not_found",
            BuildMessage(className, id, collectionName)
        );
    }
}