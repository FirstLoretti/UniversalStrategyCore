namespace UniversalStrategyCore.Faction;

public class FactionManager
{
    private readonly Dictionary<string, FactionTemplate> _playerToFaction = [];

    public void RegisterFactionByPlayer(string playerName, FactionTemplate factionTemplate)
    {
        _playerToFaction.TryAdd(playerName, factionTemplate);
        Console.WriteLine($"[FactionManager] Игрок: {playerName} выбрал фракцию: {factionTemplate.Name}");
    }
}