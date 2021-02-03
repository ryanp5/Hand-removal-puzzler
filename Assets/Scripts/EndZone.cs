using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Detachable RedType;
    public Detachable BlueType;
    bool redFin = false;
    bool blueFin = false;
    public GameEvent finishedLevel;

    private void OnTriggerEnter(Collider other)
    {
        var detachObj = other.GetComponent<TypeOfDetachable>();
        if (detachObj != null && !detachObj.attached)
        {
            if (detachObj.detachable == RedType)
            {
                redFin = true;
            }
            if (detachObj.detachable == BlueType)
            {
                blueFin = true;
            }
            if (blueFin & redFin)
            {
                finishedLevel.Raise();
            }
        }
    }
}

