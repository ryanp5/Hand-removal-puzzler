using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfArea { InOnly,OutOnly,InAndOut}

public class DisconnectOnTrigger : MonoBehaviour
{
    public TypeOfArea area;
    public List<Detachable> detachableType = new List<Detachable>();
    private void OnTriggerExit(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();

        foreach (Detachable detach in detachableType)
        {
            if (detachObj.detachable == detach)
            {
                float distance = other.transform.position.x - transform.position.x;
                if (distance < 0)
                {
                    if (area == TypeOfArea.InAndOut || area == TypeOfArea.OutOnly)
                    {
                        detach.itemAttached.Raise();
                    }
                    //} else
                    //{
                    //    other.transform.position = new Vector3(Mathf.Clamp(other.transform.position.x, transform.position.x + other.bounds.extents.x, Mathf.Infinity), other.transform.position.y, other.transform.position.z);

                    //}
                }
                else
                {
                    if (area == TypeOfArea.InAndOut || area == TypeOfArea.InOnly)
                    {
                        detach.itemDetached.Raise();
                    }
                    //} else
                    //{
                    //    other.transform.position = new Vector3(Mathf.Clamp(other.transform.position.x,-Mathf.Infinity,transform.position.x - other.bounds.extents.x), other.transform.position.y, other.transform.position.z);
                    //}
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
    //        foreach (Detachable detach in detachableType)
    //        {
    //            if (detachObj.detachable == detach)
    //            {
    //                if (detachObj.attached)
    //                {
    //                    detach.itemDetached.Raise();
    //                }
    //                else
    //                {
    //                    detach.itemAttached.Raise();
    //                }
    //            }
    //        }
    //    }
    //    }
    //}
  
    //}
