using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateController : MonoBehaviour
{
    public State CurrentState;
    public State EntryState;
    public List<State> states = new List<State>();
    [SerializeReference]
    public List<Condtion> Condtions = new List<Condtion>();
    private void Start()
    {
        CurrentState = EntryState;
        CurrentState.OnEnterState();
    }
    
    public State GetCurrentState()
    {
        return CurrentState;
    }
    public void ChangeState(State toChangeTo)
    {
        CurrentState.OnExitState();
        toChangeTo.OnEnterState();
        CurrentState = toChangeTo;
    }
}
