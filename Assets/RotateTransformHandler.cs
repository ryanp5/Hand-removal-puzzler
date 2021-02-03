using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransformHandler : MonoBehaviour
{
    public void OnDetachReset()
    {
        Vector3 test = Vector3.zero - transform.rotation.eulerAngles;
        transform.rotation = Quaternion.identity;
    }
    public void OnAttachReset()
    {
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;

    }
}