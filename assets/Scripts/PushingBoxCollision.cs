using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBoxCollision : MonoBehaviour
{
    public List<Detachable> DetachableTypes = new List<Detachable>(); 
    public Animator animator;
    public GameObject thingBeingPushed = null;
    private HandDetachedMovement characterController;
    public bool pushing = false;
    public Vector2 pushDirStart;
    private void Start()
    {
        //animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<HandDetachedMovement>();
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    var typeofDetach = collision.gameObject.GetComponent<TypeOfDetachable>();
    //    if (typeofDetach != null)
    //    {
    //        foreach (Detachable type in DetachableTypes)
    //        {
    //            if (typeofDetach.detachable == type)
    //            {
    //                //Debug.DrawRay(collision.collider.transform.position, transform.position, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);

    //                if (collision.collider.transform.position.y >= transform.position.y - 0.2f)
    //                {
    //                    pushDirStart = new Vector2(characterController.moveVector.x, characterController.moveVector.z);
    //                    pushing = true;

    //                    animator.SetBool("Pushing", true);
    //                    thingBeingPushed = collision.gameObject;
    //                    thingBeingPushed.transform.SetParent(this.transform);
    //                    ContactPoint ContactPt = collision.GetContact(collision.contactCount - 1);
    //                    Vector2 dir = new Vector2(ContactPt.point.x, ContactPt.point.z) - new Vector2(transform.position.x, transform.position.z);
    //                    dir = dir.normalized;

    //                    animator.SetFloat("PushDirY", dir.x);
    //                    animator.SetFloat("PushDirZ", dir.y);
    //                }
    //            }
    //        }
    //    }
    //}
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

                    if (collision.collider.transform.position.y >= transform.position.y - 0.2f)
                    {
                        pushing = true;

                        animator.SetBool("Pushing", true);
                        thingBeingPushed = collision.gameObject;
                        //thingBeingPushed.transform.SetParent(this.transform);
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
        //Vector2 test = pushDirStart.normalized - new Vector2(characterController.moveVector.x, characterController.moveVector.z).normalized;
        //if (test.magnitude > 1)
        //{
        //    thingBeingPushed.transform.SetParent(null);
        //}
        //if (characterController.moveVector.magnitude < 0.1f)
        //{
        //    thingBeingPushed.transform.SetParent(null);
        //}
    }
    private void OnCollisionExit(Collision collision)
    {
        //thingBeingPushed.transform.SetParent(null);
        thingBeingPushed = null;
        pushing = false;
    }
}
