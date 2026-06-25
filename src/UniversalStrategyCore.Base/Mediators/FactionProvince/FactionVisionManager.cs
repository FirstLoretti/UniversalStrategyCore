using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class FactionVisionManager(FactionVisionTable factionVisionTable)
{
    public bool HasVisionContact(Shared.Faction target, Shared.Faction observer)
    {
        if (!factionVisionTable.VisionContact.TryGetValue(observer, out var factions))
        {
            Console.WriteLine($"[FactionVisionManager] Фракции: {observer.DisplayName} нет в словаре factionVisionTable.FactionToFactyonDiplomacyView.");
            return false;
        }
        else if (!factions.Contains(target))
        {
            Console.WriteLine($"[FactionVisionManager] Фракция: {observer.DisplayName} не видит фракцию: {target.DisplayName}.");
            return false;
        }
        Console.WriteLine($"[FactionVisionManager] Фракция: {observer.DisplayName} видит фракцию: {target.DisplayName}.");
        return true;
    }
}