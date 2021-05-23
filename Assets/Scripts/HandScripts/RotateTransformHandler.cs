using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransformHandler : MonoBehaviour
{
    private Transform parentHandTransform;
    private Quaternion originRotation;
    private Rigidbody rb;
    public void Start()
    {
        originRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }
    public void OnDetachReset()
    {
        Vector3 test = Vector3.zero - transform.rotation.eulerAngles;
        transform.rotation = Quaternion.identity;
        //transform.rotation = new Quaternion(Quaternion.identity.x, transform.rotation.y, Quaternion.identity.z, Quaternion.identity.w);
    }
    public void OnAttachReset()
    {
        transform.localPosition = Vector3.zero;
        parentHandTransform = GetComponentsInParent<Transform>()[1];
        transform.rotation = parentHandTransform.rotation;
        //transform.rotation = new Quaternion(Quaternion.identity.x,transform.rotation.y,Quaternion.identity.z,Quaternion.identity.w);

    }
    
    public void ResetRotation()
    {
        this.transform.rotation = Quaternion.identity;
    }
}