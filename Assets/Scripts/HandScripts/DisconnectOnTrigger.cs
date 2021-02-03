using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectOnTrigger : MonoBehaviour
{
    public Detachable detachableType;
    public GameEvent itemDetached;
    public GameEvent itemReAttached;
    private void OnTriggerEnter(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();
        if (detachObj != null)
        {
            if (detachObj.detachable == detachableType)
            {
                if (detachObj.attached)
                {
                    itemDetached.Raise();
                    detachObj.attached = false;
                }
                else
                {
                    itemReAttached.Raise();
                    detachObj.attached = true;
                }
            }
        }
    }
}
