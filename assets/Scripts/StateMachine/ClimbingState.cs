using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : State
{
    // Start is called before the first frame update
    //distance to go up
    private float distance = 0;
    public override void OnEnterState()
    {
        CheckifClimbAble();
        base.OnEnterState();
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }
    public void OnEndClimbAnimation()
    {
        Debug.Log("height " + distance);
        movement.character.CharacterClimb(movement.directionFacing.normalized, distance);
        movement.SetState(new WalkingState(movement));
    }
    public ClimbingState(HandDetachedMovement handDetachedMovement):base(handDetachedMovement){}
    public void CheckifClimbAble()
    {
        RaycastHit hit;
        //top racast
        if (!Physics.Raycast(movement.transform.position + movement.topOffset, movement.directionFacing, movement.climbDist,  movement.climbable, QueryTriggerInteraction.Ignore))
        {
            //bottom raycast
            if (!Physics.Raycast(movement.transform.position + movement.midOffset, movement.directionFacing, out hit, movement.climbDist, movement.climbable, QueryTriggerInteraction.Ignore))
            {
                movement.SetState(new WalkingState(movement));
                //movement.SetState(new WalkingState(movement));
                //Debug.Log("Jump");
            }
            else
            {
                for (float i = movement.midOffset.y; i < movement.topOffset.y; i += 0.01f)
                {
                    Debug.DrawRay(movement.transform.position + movement.midOffset + new Vector3(0, i, 0), movement.directionFacing, Color.red, 1.0f);
                    if (!Physics.Raycast(movement.transform.position + movement.midOffset + new Vector3(0,i,0), movement.directionFacing, out hit, movement.climbDist, movement.climbable, QueryTriggerInteraction.Ignore))
                    {
                        distance = movement.midOffset.y+ i + 0.5f;
                        movement.animator.SetTrigger("Climb");
                        break;
                    }

                }
                //Debug.Log(hit.transform.gameObject.name + " Climbed");
                //climb
                //if not currently climbing
                //get top point of mid
            }
        } else
        {
            movement.SetState(new WalkingState(movement));
        }
        //two raycasts one at high level one at mid level
        //high level false mid level true climbable
    }
    public override void UpdateState()
    {
        
        base.UpdateState();
    }
    //IEnumerator Climb(float climbTime, float distance)
    //{
    //    movement.character.CharacterClimb(movement.directionFacing, distance);
    //    movement.SetState(new WalkingState(movement));
    //}
   
}
