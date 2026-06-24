namespace UniversalStrategyCore.Shared;

public interface IUndoAction
{
    public void Undo();
    public void Redo();
}