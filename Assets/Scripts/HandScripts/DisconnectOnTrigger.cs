using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectOnTrigger : MonoBehaviour
{
    public TypeOfArea area;
    public List<Detachable> detachableType = new List<Detachable>();
    private BoxCollider AreaCollider;
    public Detachable box;
    public bool waitForDisconnect = true;
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
    IEnumerator WaitForDetach(float seconds)
    {
        waitForDisconnect = false;
        yield return new WaitForSeconds(seconds);
        waitForDisconnect = true;
    }

    //Note: only work on x axis currently
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
                            StartCoroutine(WaitForDetach(0.2f));
                            detach.itemDetached.Raise();
                            //this.enabled = false;
                        }
                    }
                }
            }
        }
    }
}
