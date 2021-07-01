using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Condtion 
{
    public string name;
    public virtual void Subscribe()
    {

    }
    public virtual void Unsubscribe()
    {
        
    }
}
public class GameEventCondition : Condtion
{
    public GameEvent gameEvent;
    public override void Subscribe()
    {
        
    }
}
public class FloatCondition : Condtion
{
    public FloatVariable num;
}
public class Vector2Condition : Condtion
{
    public Vector2Variable vec;
}
public class BoolCondition: Condtion
{
    public bool Value;
}

[CreateAssetMenu(menuName = "StateMachine/Transition", fileName = "Transition")]
public class Transition : ScriptableObject
{
    public State TooState;
    [SerializeReference]
    public List<Condtion> conditions = new List<Condtion>();
}
