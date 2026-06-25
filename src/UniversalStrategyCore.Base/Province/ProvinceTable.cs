using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.ProvinceSystem;

public record ProvinceTable : IProvinceTable
{
    public IReadOnlyList<Shared.Province> AllProvinces => _provinces;

    private readonly List<Shared.Province> _provinces = [];
    private readonly Dictionary<ProvinceId, Shared.Province> _idToProvince = [];

    public ProvinceTable()
    {
        CreateProvince();
    }

    public Shared.Province GetProvince(ProvinceId id)
    {
        if (_idToProvince.TryGetValue(id, out var province))
        {
            return province;
        }
        throw new ArgumentException($"[ProvinceTable] Провинция: {id} не добавлена в таблицу");
    }

    private void CreateProvince()
    {
        AddProvince(new Shared.Province(Id: new ProvinceId("london"), "London"));
        AddProvince(new Shared.Province(Id: new ProvinceId("paris"), "Paris"));
    }

    private void AddProvince(Shared.Province province)
    {
        _idToProvince.Add(province.Id, province);
        _provinces.Add(province);
    }
}