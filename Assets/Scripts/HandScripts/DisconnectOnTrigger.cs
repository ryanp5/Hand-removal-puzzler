using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfArea { InOnly,OutOnly,InAndOut}

public class DisconnectOnTrigger : MonoBehaviour
{
    public TypeOfArea area;
    public List<Detachable> detachableType = new List<Detachable>();
    [Header("Detachable master list")]
    public DetachableMasterList Detachables;
    private BoxCollider AreaCollider;
    //private void Start()
    //{
    //    AreaCollider = GetComponent<BoxCollider>();
    //    if (area == TypeOfArea.InAndOut)
    //    {

    //    } else if (area == TypeOfArea.InOnly)
    //    {

    //    } else if (area == TypeOfArea.OutOnly)
    //    {

    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();
        if (detachObj != null)
        {
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
}
    //private void OnCollisionEnter(Collision other)
    //{
    //    var detachObj = other.collider.GetComponent<TypeOfDetachable>();
    //    if (detachObj != null)
    //    {
    //        foreach (Detachable detach in detachableType)
    //        {
    //            if (detachObj.detachable == detach)
    //            {

//                    if (area == TypeOfArea.InAndOut || area == TypeOfArea.OutOnly)
//                    {
//                        detach.itemAttached.Raise();

//                    }
//                    //} else
//                    //{
//                    //    other.transform.position = new Vector3(Mathf.Clamp(other.transform.position.x, transform.position.x + other.bounds.extents.x, Mathf.Infinity), other.transform.position.y, other.transform.position.z);

//                    //}

//                    if (area == TypeOfArea.InAndOut || area == TypeOfArea.InOnly)
//                    {
//                        detach.itemDetached.Raise();
//                    }
//                    //} else
//                    //{
//                    //    other.transform.position = new Vector3(Mathf.Clamp(other.transform.position.x,-Mathf.Infinity,transform.position.x - other.bounds.extents.x), other.transform.position.y, other.transform.position.z);
//                    //}
//                }
//            }

//    }
//}


