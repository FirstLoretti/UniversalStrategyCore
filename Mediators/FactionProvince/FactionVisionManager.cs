using UniversalStrategyCore.Share;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class FactionVisionManager(FactionVisionTable factionVisionTable)
{
    public bool HasVisionContact(FactionTemplate target, FactionTemplate observer)
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