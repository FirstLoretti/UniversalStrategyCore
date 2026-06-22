namespace UniversalStrategyCore.ConstructionSystem.Logic;

public interface IUndoAction
{
    public void Undo();
    public void Redo();
}