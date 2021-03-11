using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnetOnCollision : MonoBehaviour
{
    public TypeOfArea area;
    public List<Detachable> detachableType = new List<Detachable>();
    private BoxCollider AreaCollider;
    public Detachable box;
    private void Start()
    {
        AreaCollider = GetComponent<BoxCollider>();
        if (area == TypeOfArea.InAndOut)
        {

        }
        else if (area == TypeOfArea.InOnly)
        {

        }
        else if (area == TypeOfArea.OutOnly)
        {

        }
    }
    
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
                        //if (area == TypeOfArea.InAndOut || area == TypeOfArea.OutOnly)
                        //{
                        //    if (detachObj.detachable == box)
                        //    {
                        //        detach.itemAttached.Raise();
                        //    }
                        //}
                        
                    }
                    else
                    {
                        if (area == TypeOfArea.InAndOut || area == TypeOfArea.InOnly)
                        {
                            detach.itemDetached.Raise();
                            //this.enabled = false;
                        }
                    }
                }
            }
        }
    }
}
