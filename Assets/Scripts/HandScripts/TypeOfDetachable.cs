using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfDetachable : MonoBehaviour
{
    public Detachable detachable;
    public bool attached = true;

    public void SetAttached(bool value)
    {
        attached = value;
    }
}
