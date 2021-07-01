using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfArea { InOnly,OutOnly,InAndOut}

public class DisconnectOnCollision : MonoBehaviour
{
    public TypeOfArea area;
    public List<Detachable> detachableType = new List<Detachable>();
    private BoxCollider AreaCollider;
    public GameObject triggerAttacher;
    public Detachable box;
    private DisconnectOnTrigger disconnetOnCollision;
    private void Start()
    {
        disconnetOnCollision = GetComponentInChildren<DisconnectOnTrigger>();
        AreaCollider = GetComponent<BoxCollider>();
        //Physics.IgnoreLayerCollision(13, 14);
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
    
    private void OnCollisionEnter(Collision collision)
    {
        var detachObj = collision.collider.GetComponent<TypeOfDetachable>();
        if (detachObj != null)
        {
            foreach (Detachable detach in detachableType)
            {
                if (detachObj.detachable == detach)
                {
                    if (area == TypeOfArea.InAndOut || area == TypeOfArea.OutOnly)
                    {
                        if (disconnetOnCollision.waitForDisconnect)
                        {
                            detach.itemAttached.Raise();
                            triggerAttacher.SetActive(true);
                        }
                    }
                }

            }
        }
    }
}


