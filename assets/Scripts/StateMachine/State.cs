using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State
{
    //Transitions possible from this state
    protected HandDetachedMovement movement;
    public State(HandDetachedMovement handDetachedMovement){
        movement = handDetachedMovement;
    }
    //called once On entering state
    public virtual void OnEnterState()
    {
        //Debug.Log("Entering State " + this.GetType().Name);
    }
    //called once when exiting state.
    public virtual void OnExitState()
    {
        //Debug.Log("Exiting State " + this.GetType().Name);
    }
    //Logic for state while in update loop.
    public virtual void UpdateState()
    {
    }
    //Logic for state to be used in FixedUpdateLoop.
    public virtual void FixedUpdateState()
    {
    }
    //All Logic that handles whether to leave state here
    public virtual void HandleInput()
    {

    }
}
