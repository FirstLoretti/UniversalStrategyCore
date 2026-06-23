namespace UniversalStrategyCore.Map.WeatherLogic;

public interface IMapWeatherPenaltiesTable
{
    public Dictionary<MapPenaltyTypeForArmy, float> GetPenalties(MapWeatherType mapWeatherType);
}