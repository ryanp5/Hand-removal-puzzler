using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    //might turn into datatype
    public List<Detachable> KillableTypes = new List<Detachable>();
    public GameEvent resetScene;
    private void OnTriggerEnter(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();
        if (detachObj != null)
        {
            foreach(Detachable d in KillableTypes)
            {
                if (detachObj.detachable == d)
                {
                    resetScene.Raise();
                }
            }
        }
    }


}
