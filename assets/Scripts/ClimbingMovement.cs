using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HandDetachedMovement))]
public class ClimbingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask climbable;
    public Vector3 topOffset;
    public Vector3 midOffset;
    public float climbDist;
    public float climbTime;
    private HandDetachedMovement detachedMovement; 
    void Start()
    {
        detachedMovement = GetComponent<HandDetachedMovement>();
    }

    // Update is called once per frame
    public void CheckifClimbAble()
    {
        RaycastHit hit;
       
        //top racast
        if (!Physics.Raycast(transform.position + topOffset, detachedMovement.directionFacing, climbDist, climbable, QueryTriggerInteraction.Ignore))
        {
            //bottom raycast
            if (!Physics.Raycast(transform.position + midOffset, detachedMovement.directionFacing, out hit, climbDist, climbable, QueryTriggerInteraction.Ignore))
            {
                Debug.Log("Jump");
            } else
            {
                Debug.Log(hit.transform.gameObject.name + " Climbed");
                //climb
                detachedMovement.StartCoroutine("Climb", climbTime);
                //get top point of mid
            }
        }
        //two raycasts one at high level one at mid level
        //high level false mid level true climbable
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position+topOffset, (detachedMovement.directionFacing* climbDist)+topOffset);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + midOffset, (transform.position* climbDist)+midOffset);
    }
}
