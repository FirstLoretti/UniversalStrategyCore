using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class FactionVisionManager(FactionVisionTable factionVisionTable)
{
    public bool HasVisionContact(FactionTemplate target, FactionTemplate observer)
    {
        if (!factionVisionTable.VisionContact.TryGetValue(observer, out var factions))
        {
            Console.WriteLine($"[FactionVisionManager] Фракции: {observer.Name} нет в словаре factionVisionTable.FactionToFactyonDiplomacyView.");
            return false;
        }
        else if (!factions.Contains(target))
        {
            Console.WriteLine($"[FactionVisionManager] Фракция: {observer.Name} не видит фракцию: {target.Name}.");
            return false;
        }
        Console.WriteLine($"[FactionVisionManager] Фракция: {observer.Name} видит фракцию: {target.Name}.");
        return true;
    }
}