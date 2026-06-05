namespace InsideTheWar.Armies;

public class ArmyManager
{
    public Dictionary<int, Army> IdAndArmy { get; private set; } = [];

    public void RegisterArmy(Army army)
    {
        IdAndArmy.TryAdd(army.Id, army);
        army.OnArmyDestroyed += OnArmyDestroyed;
    }

    public void OnArmyDestroyed(Army army)
    {
        Console.WriteLine($"Армия с id: {army.Id} уничтожена");
        army.OnArmyDestroyed -= OnArmyDestroyed;
        IdAndArmy.Remove(army.Id);
    }
}