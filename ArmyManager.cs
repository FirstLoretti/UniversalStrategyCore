namespace InsideTheWar.Armies;

public class ArmyManager
{
    public Dictionary<int, Army> Armies { get; private set; } = [];

    public void RegisterArmy(Army army)
    {
        Armies.TryAdd(army.Id, army);
        army.ArmyDestroyed += OnArmyDestroyed;
    }

    public void OnArmyDestroyed(Army army)
    {
        Console.WriteLine($"Армия с id: {army.Id} удалена");
        army.ArmyDestroyed -= OnArmyDestroyed;
        Armies.Remove(army.Id);
    }
}