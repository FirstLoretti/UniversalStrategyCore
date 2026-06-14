
using Microsoft.Extensions.DependencyInjection;
using UniversalStrategyCore.Turn;

namespace UniversalStrategyCore.Commands.Turn;

public class EndTurnCommand(string playerName) : ICommand
{
    public void Execute(IServiceProvider serviceProvider)
    {
        var turnManager = serviceProvider.GetRequiredService<TurnManager>();
        turnManager.TurnEnd(playerName);
    }
}