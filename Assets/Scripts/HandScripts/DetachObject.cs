using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachObject : MonoBehaviour
{
    public GameObject Parent;
    
    private void Start()
    {
        //Parent = gameObject.transform.parent.gameObject;
    }
    public void DettachObject()
    {
        gameObject.transform.parent = null;
    }
    public void AttachObject()
    {
        gameObject.transform.parent = Parent.transform;
    }
}
