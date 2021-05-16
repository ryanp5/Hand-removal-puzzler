using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBoxCollision : MonoBehaviour
{
    public List<Detachable> DetachableTypes = new List<Detachable>(); 
    private Animator animator;
    public GameObject thingBeingPushed = null;
    private HandDetachedMovement characterController;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<HandDetachedMovement>();
    }
    private void OnCollisionStay(Collision collision)
    {
        var typeofDetach = collision.gameObject.GetComponent<TypeOfDetachable>();
        if (typeofDetach != null)
        {
            foreach (Detachable type in DetachableTypes)
            {
                if (typeofDetach.detachable == type)
                {
                     //Debug.DrawRay(collision.collider.transform.position, transform.position, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);

                    if (collision.collider.transform.position.y >= transform.position.y -0.2f)
                    {
                        animator.SetBool("Pushing", true);
                        thingBeingPushed = collision.gameObject;

                        ContactPoint ContactPt = collision.GetContact(collision.contactCount - 1);
                        Vector2 dir = new Vector2(ContactPt.point.x, ContactPt.point.z) - new Vector2(transform.position.x, transform.position.z);
                        dir = dir.normalized;
                        
                            animator.SetFloat("PushDirY", dir.x);
                            animator.SetFloat("PushDirZ", dir.y);
                   


                    }
                    //foreach (var item in collision.GetContacts())
                    //{
                    //    Debug.DrawRay(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
                    //}
                } 
            }
        }
    }
    private void Update()
    {
        if (thingBeingPushed == null)
        {
            animator.SetBool("Pushing", false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        thingBeingPushed = null;        
    }
}
