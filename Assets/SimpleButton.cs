using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public GameEvent buttonPressed;
    public GameEvent buttonReleased;
    public List<Detachable> interactables = new List<Detachable>();

    private void OnTriggerEnter(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();
        if (detachObj != null)
        {
            foreach (Detachable d in interactables)
            {
                if (detachObj.detachable == d)
                {
                    buttonPressed.Raise();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();
        if (detachObj != null)
        {
            foreach (Detachable d in interactables)
            {
                if (detachObj.detachable == d)
                {
                    buttonReleased.Raise();
                }
            }
        }
    }
}
