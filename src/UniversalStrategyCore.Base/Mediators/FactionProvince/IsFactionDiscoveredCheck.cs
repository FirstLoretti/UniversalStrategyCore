using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class IsFactionDiscoveredCheck(
    FactionVisionManager visionManager,
    Shared.Faction observer
) : ICheck<Shared.Faction>
{
    public bool IsPassed(Shared.Faction faction) => visionManager.HasVisionContact(faction, observer);
}