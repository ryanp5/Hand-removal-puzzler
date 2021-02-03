using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleCharacterController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float Speed = 0.1f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;
    public bool isGrounded;
    private Transform groundCheck;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        groundCheck = transform.GetChild(0);
    }
    private bool CheckIfGrounded()
    {
        //if (Physics.Raycast(groundCheck.position, Vector3.down, GroundDistance, Ground, QueryTriggerInteraction.Ignore)){
        if (Physics.CheckBox(groundCheck.position, new Vector3(0.5f,0.5f,0.5f),Quaternion.identity, Ground, QueryTriggerInteraction.Ignore)){
            return true;
        } else
        {
            return false;
        }
    }
    private void Update()
    {
        isGrounded = CheckIfGrounded();   
    }
    public void Move(Vector3 vector3)
    {
        rigidbody.MovePosition(rigidbody.position+ vector3* Speed*Time.fixedDeltaTime);
    }
}
