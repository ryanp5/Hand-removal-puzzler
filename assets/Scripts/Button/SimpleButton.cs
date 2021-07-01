using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public GameEvent buttonPressed;
    public GameEvent buttonReleased;
    public List<Detachable> interactables = new List<Detachable>();
    private TypeOfDetachable detachable = null;
    private int num = 0;
    //Note: Will need to fix how bridge goes up and down after
    private void OnTriggerEnter(Collider other)
    {
        num++;
        detachable = other.GetComponent<TypeOfDetachable>();
        if (detachable != null)
        {
            foreach (Detachable d in interactables)
            {
                if (detachable.detachable == d)
                {
                    buttonPressed.Raise();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        num--;
        var detachObj = other.GetComponent<TypeOfDetachable>();
        
        if (detachObj == detachable)
        {
            foreach (Detachable d in interactables)
            {
                if (detachObj.detachable)
                {
                    if (num == 0)
                    {
                        buttonReleased.Raise();
                    }
                }
            }
        }
    }
}
