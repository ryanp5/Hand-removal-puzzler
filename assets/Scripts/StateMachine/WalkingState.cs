using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : State
{
    public WalkingState(HandDetachedMovement handDetachedMovement) : base(handDetachedMovement) { }
    public override void OnEnterState()
    {
        movement.animator.SetBool("IsGrounded", true);
        movement.moveVector = Vector3.zero;
        base.OnEnterState();
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }
    public override void FixedUpdateState()
    {
        if (movement.moveVector.magnitude > 0.2f)
            movement.character.Move(movement.moveVector);
        
    }
    //public override void HandleInput()
    //{
    //    if (movement.detachable.attached)
    //    {
    //        movement.SetState(new AttachedState(movement));
    //    }
    //    base.HandleInput();
    //}
    public override void UpdateState()
    {
        base.UpdateState();
        if (!movement.character.isGrounded)
        {
            Debug.Log("falling");
            movement.SetState(new FallingState(movement));
        }
        movement.moveVector = Vector3.zero;
        movement.moveVector = new Vector3(movement.input.value.y, 0, -movement.input.value.x);
        //movement.animator.SetBool("IsGrounded", true);
        if (movement.moveVector.magnitude > 0.2f)
        {
            movement.directionFacing = new Vector3(movement.moveVector.x, 0, movement.moveVector.z);
            movement.animator.SetFloat("LastVelY", movement.moveVector.x, 0.1f, Time.deltaTime);
            //animator.SetFloat("LastVelY", moveVector.x);
            movement.animator.SetFloat("LastVelZ", movement.moveVector.z, 0.1f, Time.deltaTime);
            //animator.SetFloat("LastVelZ", moveVector.z);

            //climbing
            float clampY = movement.moveVector.x;
            float clampZ = movement.moveVector.z;
            if (Mathf.Abs(movement.moveVector.x) > Mathf.Abs(movement.moveVector.z))
            {
                clampZ = 0;
            }
            else
            {
                clampY = 0;
            }
            movement.animator.SetFloat("VelocityClampY", clampY);
            movement.animator.SetFloat("VelocityClampZ", clampZ);
            movement.animator.SetFloat("VelocityY", movement.moveVector.x, 0.1f, Time.deltaTime);
            movement.animator.SetFloat("VelocityZ", movement.moveVector.z, 0.1f, Time.deltaTime);
        } else
        {
            movement.animator.SetFloat("VelocityY", 0, 0.1f, Time.deltaTime);
            movement.animator.SetFloat("VelocityZ", 0, 0.1f, Time.deltaTime);
        }
    }
    
}
