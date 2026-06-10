namespace UniversalStrategyCore.Managers;

public class TurnManager
{
    public event Action<string>? TurnEnded;

    public void TurnEnd(string playerName)
    {
        TurnEnded?.Invoke(playerName);
    }
}