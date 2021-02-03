using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectOnTrigger : MonoBehaviour
{
    public List<Detachable> detachableType = new List<Detachable>();
    
    private void OnTriggerExit(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();
        if (detachObj != null)
        {
            foreach (Detachable detach in detachableType)
            {
                if (detachObj.detachable == detach)
                {
                    if (detachObj.attached)
                    {
                        detach.itemDetached.Raise();
                    }
                    else
                    {
                        detach.itemAttached.Raise();
                    }
                }
            }
        }
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    var detachObj = other.GetComponent<TypeOfDetachable>();
    //    if (detachObj != null)
    //    {
    //        if (detachObj.detachable == detachableType)
    //        {
    //            if (detachObj.attached)
    //            {
    //                itemReAttached.Raise();
    //                count++;
    //            }
    //            else
    //            {
    //                itemDetached.Raise();
    //            }
    //        }
    //    }
    //}
