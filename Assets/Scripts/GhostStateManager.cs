using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal;

public enum GhostStates
{
    SCATTERSTATE,
    CHASESTATE,
    FREIGHTENEDSTATE
}


public class GhostStateManager : MonoBehaviour
{
    private Dictionary<GhostStates, AbstractState<GhostStates>> states = new Dictionary<GhostStates,
        AbstractState<GhostStates>>
    {
        {GhostStates.SCATTERSTATE, new ScatterState()}
    };

    private AbstractState<GhostStates> currentState;
    private bool isTransitioningStates = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = states[GhostStates.SCATTERSTATE];
        currentState?.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        GhostStates nextState = currentState.GetNextState();
        if (nextState.Equals(currentState.StateKey)) currentState.UpdateState();
        else if (!isTransitioningStates) TransitionToState(nextState);
    }

    public void TransitionToState(GhostStates stateKey)
    {
        Debug.Log(currentState);
        isTransitioningStates = true;
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioningStates = false;
    }

}
