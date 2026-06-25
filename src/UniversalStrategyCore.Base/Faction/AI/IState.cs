namespace UniversalStrategyCore.Factionn.AI;

public interface IState
{
    public IStrategy Strategy {get;}
    public void Update(AIFaction faction);
}