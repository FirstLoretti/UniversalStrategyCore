using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.ProvinceSystem;

public class ProvinceManager
{
    private readonly Dictionary<string, HashSet<Shared.Province>> _playerToProvinces = [];

    public void AddPlayerProvinces(string playerName, HashSet<Shared.Province> provinces)
    {
        _playerToProvinces.TryAdd(playerName, provinces);
    }

    public HashSet<Shared.Province> GetPlayerProvinces(string playerName)
    {
        if (_playerToProvinces.TryGetValue(playerName, out var provinces))
        {
            return provinces;
        }
        throw new ArgumentException($"[ProvinceManager] Игрок {playerName} не зарегестрирован в _playerToProvince");
    }

    public Shared.Province GetPlayerProvince(string playerName, ProvinceId id)
    {
        if (_playerToProvinces.TryGetValue(playerName, out var provinces))
        {
            foreach(var province in provinces)
            {
                if(province.Id == id)
                {
                    return province;
                }
                throw new ArgumentException($"[ProvinceManager] Игрок {playerName} не владеет провинцией: {id}");
            }
        }
        throw new ArgumentException($"[ProvinceManager] Игрок {playerName} не зарегистрирован в _playerToProvince");
    }

    public void RemovePlayerProvinces(string playerName)
    {
        _playerToProvinces.Remove(playerName);
    }
}