namespace UniversalStrategyCore.Shared;

public interface IReversibleCommand
{
    public void Apply();
    public void Undo();
}