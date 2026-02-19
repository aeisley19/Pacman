using UnityEngine;

public abstract class AbstractState<GhostStates> 
{

    public AbstractState(GhostStates state)
    {
        StateKey = state;
    }
    public GhostStates StateKey { get; private set; }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract GhostStates GetNextState();
}
