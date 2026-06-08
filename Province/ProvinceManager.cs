namespace InsideTheWar.Provinces;

public class ProvinceManager
{
    public Dictionary<int, Province> IdAndProvince { get; private set; } = [];
    public Dictionary<string, Province> HolderProvinces { get; private set; } = [];

    public void RegisterProvince(Province province, string holderName)
    {
        IdAndProvince.TryAdd(province.Id, province);
        HolderProvinces.TryAdd(holderName, province);
    }

    public void RemoveProvince(Province province, string holderName)
    {
        IdAndProvince.Remove(province.Id);
        HolderProvinces.Remove(holderName);
    }
}