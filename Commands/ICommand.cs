namespace UniversalStrategyCore.Commands;

public interface ICommand
{
     public void Execute(IServiceProvider serviceProvider);
}