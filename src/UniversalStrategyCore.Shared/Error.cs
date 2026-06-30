using System.Runtime.CompilerServices;
using System.Text;

namespace UniversalStrategyCore.Shared;

public record Error(string Message)
{
    public static Error NotEnoughtResources(Dictionary<GameResourceType, int> resources)
        => new(BuildNotEnoughtResourcesMessage(resources));

    public static Error SquadDestroyed(int id, [CallerFilePath] string path = "")
        => new($"[{Path.GetFileNameWithoutExtension(path)}] Отряд: {id} уничтожен");

    public static Error AlreadyExist<T>(T entityId, string collectionName, [CallerFilePath] string path = "") where T : struct
        => new(BuildAlredyExistMessage(Path.GetFileNameWithoutExtension(path), $"{entityId}", collectionName));

    public static Error NotFound<T>(T entityId, string collectionName, [CallerFilePath] string path = "") where T : struct
        => new(BuildNotFoundMessage(Path.GetFileNameWithoutExtension(path), $"{entityId}", collectionName));

    private static string BuildNotEnoughtResourcesMessage(Dictionary<GameResourceType, int> resources)
    {
        StringBuilder builder = new("Недостаточно ресурсов:\n");
        foreach(var resource in resources)
        {
            builder.AppendLine($"{resource.Key}, нужно ещё {resource.Value}");
        }
        return builder.ToString();
    }

    private static string BuildAlredyExistMessage(string className, string entityId, string collectionName)
        => $"[{className}] {entityId} уже содержится в {collectionName}";

    private static string BuildNotFoundMessage(string className, string entityId, string collectionName)
        => $"[{className}] {entityId} не содержится в {collectionName}";
}