using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Factions;

public class FactionPlayerRegistrar
{
    private readonly Dictionary<string, Shared.Faction> _playerToFaction = [];

    public void RegisterFactionByPlayer(string playerName, Shared.Faction faction)
    {
        _playerToFaction.TryAdd(playerName, faction);
        Console.WriteLine($"[FactionManager] Игрок: {playerName} выбрал фракцию: {faction.DisplayName}");
    }
}