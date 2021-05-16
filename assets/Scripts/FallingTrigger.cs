using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    private TypeOfDetachable detachable;
    public Animator animator;
    private SimpleCharacterController controller;
    public LayerMask groundLayerMask;
    public float distanceToTrigger;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SimpleCharacterController>();
        detachable = GetComponent<TypeOfDetachable>();
        
    }
    void Update()
    {
        if (!detachable.attached)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, groundLayerMask, QueryTriggerInteraction.Ignore);
            if (hit.distance < distanceToTrigger && !controller.isGrounded)
            {
                //note: setting the trigger every frame may need to fix later
                animator.SetBool("Landing",true);
            } else
            {
                animator.SetBool("Landing", false);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.TransformDirection(Vector3.down) * distanceToTrigger);
    }
}
