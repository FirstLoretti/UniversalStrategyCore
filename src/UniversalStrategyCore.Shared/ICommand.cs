namespace UniversalStrategyCore.Shared;

public interface ICommand
{
     public void Execute(IServiceProvider serviceProvider);
}