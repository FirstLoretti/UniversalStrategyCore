namespace InsideTheWar.PlayerRegistrar;

public class Player(string name, bool isAI)
{
    public string Name { get; init; } = name;
    public bool IsAI { get; private set; } = isAI;
}