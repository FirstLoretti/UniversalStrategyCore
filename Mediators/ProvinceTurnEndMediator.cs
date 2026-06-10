using UniversalStrategyCore.Managers;
using UniversalStrategyCore.Provinces;

namespace UniversalStrategyCore.Mediators;

public class ProvinceTurnEndMediator
{
    private readonly TurnManager _turnManager;
    private readonly ProvinceManager _provinceManager;

    public ProvinceTurnEndMediator(TurnManager turnManager, ProvinceManager provinceManager)
    {
        _turnManager = turnManager;
        _provinceManager = provinceManager;
        _turnManager.TurnEnded += OnTurnEnd;
    }

    public void Destroy()
    {
        _turnManager.TurnEnded -= OnTurnEnd;
    }

    private void OnTurnEnd(string playerName)
    {
        Console.WriteLine($"[TurnEndMediator] Конец хода игрока: {playerName}");
        foreach (var province in _provinceManager.HolderProvinces)
        {
            if (province.Key == playerName)
            {
                province.Value.OnTurnEnd();
                Console.WriteLine($"[TurnEndMediator] Провинция: {province.Value.Name} является провинцией игрока: {playerName}");
            }
        }
    }
}