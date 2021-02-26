using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMasterList : MonoBehaviour
{
    public DetachableMasterList objectMasterList;
    private void OnEnable()
    {
        objectMasterList.Add(gameObject);
    }
    private void OnDisable()
    {
        objectMasterList.Remove(gameObject);
    }

}
