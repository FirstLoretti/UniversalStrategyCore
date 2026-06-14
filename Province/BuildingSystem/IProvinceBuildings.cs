namespace UniversalStrategyCore.Province.BuildingSystem;

public interface IProvinceBuildings
{
    public IReadOnlyList<BuildingTemplate> GetBuildings(ProvinceTemplate provinceTemplate);
}