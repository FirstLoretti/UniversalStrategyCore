using UniversalStrategyCore.Armies;
using UniversalStrategyCore.Map.WeatherLogic;

namespace UniversalStrategyCore.Mediators;

public class ArmyWeatherMediator(ArmyManager armyManager, IMapWeatherPenaltiesTable mapWeatherPenaltiesTable)
{
    public void CurrentWeatherImpactOnArmies(MapWeatherType mapWeatherType)
    {
        var penalties = mapWeatherPenaltiesTable.GetPenalties(mapWeatherType);
        var attritionCasualties = penalties[Map.MapPenaltyTypeForArmy.Attrition];
        var moralePenalty = penalties[Map.MapPenaltyTypeForArmy.Morale];
        foreach(var army in armyManager.Armies.Values)
        {
            army.TakeCasualties(attritionCasualties);
            army.MoralePenalty(moralePenalty);
            Console.WriteLine(
                $"Армия под Id: {army.Id}, понесла потери: {attritionCasualties}% от погоды: {mapWeatherType}. " +
                $"Штраф к боевому духу: {moralePenalty}%."
            );
        }
    }
}