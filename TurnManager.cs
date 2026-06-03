namespace InsideTheWar.Managers;

class TurnManager()
{
    public event Action? OnTurnEnded;

    public void TurnEnd()
    {
        OnTurnEnded?.Invoke();
    }
}