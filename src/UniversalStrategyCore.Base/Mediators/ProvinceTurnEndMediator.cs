using UniversalStrategyCore.ProvinceSystem;
using UniversalStrategyCore.Turn;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.Mediators;

public class ProvinceConstructionTurnEndMediator
{
    private readonly TurnManager _turnManager;
    private readonly IProvinceConstructionManager _provinceConstructionManager;
    private readonly ProvinceManager _provinceManager;

    public ProvinceConstructionTurnEndMediator(ProvinceManager provinceManager, IProvinceConstructionManager provinceConstructionManager, TurnManager turnManager)
    {
        _turnManager = turnManager;
        _provinceConstructionManager = provinceConstructionManager;
        _provinceManager = provinceManager;
        _turnManager.TurnEnded += OnTurnEnd;
    }

    public void Destroy()
    {
        _turnManager.TurnEnded -= OnTurnEnd;
    }

    private void OnTurnEnd(string playerName)
    {
        Console.WriteLine($"[ProvinceTurnEndMediator] Конец хода игрока: {playerName}");
        var playerProvinces = _provinceManager.GetPlayerProvinces(playerName);
        foreach (var province in playerProvinces)
        {
            _provinceConstructionManager.OnTurnEnd(province.Id);
            Console.WriteLine($"[ProvinceTurnEndMediator] Провинция: {province.DisplayName} является провинцией игрока: {playerName}");
        }
    }
}