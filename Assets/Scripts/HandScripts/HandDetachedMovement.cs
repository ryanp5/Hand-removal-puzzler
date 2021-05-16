using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleCharacterController))]
public class HandDetachedMovement : MonoBehaviour
{
    private SimpleCharacterController character;
    private TypeOfDetachable detachable;
    private Animator animator;
    public Vector2Variable input;
    public Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<SimpleCharacterController>();
        detachable = GetComponent<TypeOfDetachable>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!detachable.attached)
        {
            moveVector = Vector3.zero;
            if (!character.isGrounded)
            {
                animator.SetBool("IsGrounded", false);
                //moveVector = Physics.gravity;
            }
            else
            {
                animator.SetBool("IsGrounded", true);
                moveVector = new Vector3(input.value.y, 0, -input.value.x);
                if (moveVector.magnitude > 0.1f)
                {
                    animator.SetFloat("LastVelY", moveVector.x, 0.1f, Time.deltaTime);
                    //animator.SetFloat("LastVelY", moveVector.x);
                    animator.SetFloat("LastVelZ", moveVector.z, 0.1f, Time.deltaTime);
                    //animator.SetFloat("LastVelZ", moveVector.z);
                }
               
            }
                character.Move(moveVector);
                animator.SetFloat("VelocityY", moveVector.x, 0.1f, Time.deltaTime);
                animator.SetFloat("VelocityZ", moveVector.z, 0.1f, Time.deltaTime);
                //animator.SetFloat("VelocityY", moveVector.x);
                //animator.SetFloat("VelocityZ", moveVector.z);
           

        }

    }
    
}
