using InsideTheWar.Factions;

namespace InsideTheWar.AI.Faction;

public class AIFaction(FactionName factionName)
{
    public FactionName FactionName { get; init; } = factionName;
}