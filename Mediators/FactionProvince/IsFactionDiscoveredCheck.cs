using UniversalStrategyCore.Share;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class IsFactionDiscoveredCheck(
    FactionVisionManager visionManager,
    FactionTemplate observer
) : ICheck<FactionTemplate>
{
    public bool IsPassed(FactionTemplate faction) => visionManager.HasVisionContact(faction, observer);
}