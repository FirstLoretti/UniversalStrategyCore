namespace UniversalStrategyCore;

public interface IReversibleCommand
{
    public void Apply();
    public void Undo();
}