namespace UniversalStrategyCore.Province;

public record ProvinceTable : IProvinceTable
{
    public IReadOnlyList<ProvinceTemplate> AllProvinces => _provinces;

    private readonly List<ProvinceTemplate> _provinces = [];
    private readonly Dictionary<ProvinceName, ProvinceTemplate> _provinceNameToProvince = [];

    public ProvinceTable()
    {
        Initialization();
    }

    public ProvinceTemplate GetProvince(ProvinceName provinceName)
    {
        if (_provinceNameToProvince.TryGetValue(provinceName, out var province))
        {
            return province;
        }
        throw new ArgumentException($"[ProvinceTable] Фракция {provinceName} не добавлена в таблицу! Добавить в CreateProvince()");
    }

    private void Initialization()
    {
        CreateProvince();
    }

    private void CreateProvince()
    {
        AddProvince(new ProvinceTemplate(ProvinceName.London));
        AddProvince(new ProvinceTemplate(ProvinceName.Paris));
    }

    private void AddProvince(ProvinceTemplate provinceTemplate)
    {
        _provinceNameToProvince.Add(provinceTemplate.Name, provinceTemplate);
        _provinces.Add(provinceTemplate);
    }
}