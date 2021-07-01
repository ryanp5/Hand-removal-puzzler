using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedState :State
{
    public AttachedState(HandDetachedMovement handDetachedMovement) : base(handDetachedMovement) { }
    public override void OnEnterState()
    {
        movement.animator.SetBool("Attached", true);
        movement.animator.SetFloat("LastVelZ", 0);
        movement.animator.SetFloat("LastVelY", 0);
        base.OnEnterState();
        
    }
    public override void OnExitState()
    {
        movement.animator.SetBool("Attached", false);
        movement.animator.SetFloat("LastVelZ", 0);
        movement.animator.SetFloat("LastVelY", 0);
        base.OnExitState();
    }
    public void Detach()
    {
        movement.SetState(new WalkingState(movement));
    }
    //public override void HandleInput()
    //{
    //    if (!movement.detachable.attached)
    //    {
    //        movement.SetState(new WalkingState(movement));
    //    }
    //    base.HandleInput();
    //}
}
