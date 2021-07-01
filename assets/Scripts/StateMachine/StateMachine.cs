using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateMachine :MonoBehaviour
{
    protected State activeState;
    public void SetState(State state)
    {
        if (activeState != null) {
            activeState.OnExitState();
        }
        activeState = state;
        activeState.OnEnterState();
    }
    public State GetActiveState()
    {
        return activeState;
    }
    public bool CheckIfState(State state)
    {
        if (activeState.GetType() == state.GetType())
        {
            return true;
        } else
        {
            return false;
        }
    }
}
