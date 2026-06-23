using UniversalStrategyCore.Share;

namespace UniversalStrategyCore.Province;

public record ProvinceTable : IProvinceTable
{
    public IReadOnlyList<ProvinceTemplate> AllProvinces => _provinces;

    private readonly List<ProvinceTemplate> _provinces = [];
    private readonly Dictionary<ProvinceId, ProvinceTemplate> _idToProvince = [];

    public ProvinceTable()
    {
        CreateProvince();
    }

    public ProvinceTemplate GetProvince(ProvinceId id)
    {
        if (_idToProvince.TryGetValue(id, out var province))
        {
            return province;
        }
        throw new ArgumentException($"[ProvinceTable] Провинция: {id} не добавлена в таблицу");
    }

    private void CreateProvince()
    {
        AddProvince(new ProvinceTemplate(Id: new ProvinceId("london"), "London"));
        AddProvince(new ProvinceTemplate(Id: new ProvinceId("paris"), "Paris"));
    }

    private void AddProvince(ProvinceTemplate province)
    {
        _idToProvince.Add(province.Id, province);
        _provinces.Add(province);
    }
}