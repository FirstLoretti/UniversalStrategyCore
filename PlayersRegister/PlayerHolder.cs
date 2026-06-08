namespace InsideTheWar.PlayerRegistrar;

public class PlayerHolder
{
    public Dictionary<string, Player> Players {get; private set;} = [];

    public void RegisterPlayer(Player player)
    {
        if (!Players.TryAdd(player.Name, player))
        {
            Console.Write($"Игрок c именем: {player.Name} уже существует");
        }
    }
}