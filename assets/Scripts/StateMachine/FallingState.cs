using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State
{
    public FallingState(HandDetachedMovement handDetachedMovement) : base(handDetachedMovement) { }
    public override void OnEnterState()
    {
        movement.animator.SetBool("IsGrounded", false);
        base.OnEnterState();
    }
    public override void OnExitState()
    {
        movement.animator.SetBool("IsGrounded", true);
        base.OnExitState();
    }
    public override void UpdateState()
    {
        if (movement.character.isGrounded)
        {
           movement.SetState(new WalkingState(movement));
        }
        base.UpdateState();
    }
}
