using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour
{
    public List<Detachable> interactables = new List<Detachable>();
    public Vector3 lowestpointButton;
    public Vector3 startingPos;
    private Collider interactable = null;
    public bool interacting;

    private void Start()
    {
        //lowestpointButton = transform.GetChild(0).GetComponent<Transform>().position;
        //startingPos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    var detachObj = other.GetComponent<TypeOfDetachable>();
    //    if (detachObj != null)
    //    {
    //        foreach (Detachable d in interactables)
    //        {
    //            if (detachObj.detachable == d)
    //            {
    //                Debug.Log(other.gameObject.GetComponent<Rigidbody>().velocity.y);
    //                if (other.gameObject.GetComponent<Rigidbody>().velocity.y < 0)
    //                {
    //                    interacting = true;
    //                    interactable = other;
    //                }

    //            }
    //        }
    //    }
    //}

    //private void MoveButton()
    //{
    //    float lowest = interactable.ClosestPoint(lowestpointButton).y;
    //    Collider collider = GetComponent<Collider>();
    //    float yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);

    //    transform.position = new Vector3(transform.position.x, lowest, transform.position.z);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    var detachObj = other.GetComponent<TypeOfDetachable>();
    //    if (detachObj != null)
    //    {
    //        foreach (Detachable d in interactables)
    //        {
    //            if (detachObj.detachable == d)
    //            {
    //                interacting = false;
    //            }
    //        }
    //    }
    //}

    //private void ResetPosition()
    //{
    //    //transform.position = startingPos;
    //}

    //private void Update()
    //{
    //    if (interacting)
    //    {
    //        MoveButton();
    //    } else
    //    {
    //        ResetPosition();
    //    }
    //}
}
