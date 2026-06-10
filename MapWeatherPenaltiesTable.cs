namespace UniversalStrategyCore.Map.WeatherLogic;

public class MapWeatherPenaltiesTable : IMapWeatherPenaltiesTable
{
    private readonly Dictionary<MapWeatherType, float> _turnEndWeatherAttritionPercent = new()
    {
        {MapWeatherType.Sun, 0.0f},
        {MapWeatherType.Rain, 5.0f},
        {MapWeatherType.Snow, 15.0f}
    };
    private readonly Dictionary<MapWeatherType, float> _turnEndWeatherPenaltyMoralePercent = new()
    {
        {MapWeatherType.Sun, 0.0f},
        {MapWeatherType.Rain, 2.5f},
        {MapWeatherType.Snow, 5.0f}
    };

    public Dictionary<MapPenaltyTypeForArmy, float> GetPenalties(MapWeatherType mapWeatherType)
    {
        var attritionPenalty = _turnEndWeatherAttritionPercent[mapWeatherType];
        var moralePenalty = _turnEndWeatherPenaltyMoralePercent[mapWeatherType];
        Dictionary<MapPenaltyTypeForArmy, float> penalties = new()
        {
            {MapPenaltyTypeForArmy.Attrition, attritionPenalty},
            {MapPenaltyTypeForArmy.Morale, moralePenalty}

        };
        return penalties;
    }
}