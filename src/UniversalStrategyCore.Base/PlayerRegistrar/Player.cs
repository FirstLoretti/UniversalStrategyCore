namespace UniversalStrategyCore.PlayerRegistrar;

/// <summary>
/// Создание игроков только через PlayerManager.CreatePlayer()
/// </summary>
public class Player(string name, bool isAI)
{
    public string Name { get; init; } = name;
    public bool IsAI { get; init; } = isAI;
}