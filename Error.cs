using UniversalStrategyCore.FactionEconomicSystem;

namespace UniversalStrategyCore;

public record Error(string Id, string Text)
{
    public static Error PlayerAlredyExist() => new("player_exist", "Игрок с таким именем уже существует");
    public static Error NotEnoughtResource(ResourceType resource) => new("not_enought_resource", $"Не хватает {resource}");
}