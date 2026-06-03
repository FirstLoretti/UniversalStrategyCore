using InsideTheWar.Provinces;

namespace InsideTheWar.Map;

class WorldMap
{
    private Dictionary<int, Province> _idAndProvinceName = [];

    public void AddProvince(Province province)
    {
        _idAndProvinceName.Add(province.Id, province);
    }

    public Province? GetProvince(int id)
    {
        _idAndProvinceName.TryGetValue(id, out Province? province);
        return province;
    }
}