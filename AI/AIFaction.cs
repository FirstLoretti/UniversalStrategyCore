using UniversalStrategyCore.Factions;

namespace UniversalStrategyCore.AI.Faction;

public class AIFaction(FactionName factionName)
{
    public FactionName FactionName { get; init; } = factionName;
}