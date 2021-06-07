using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleCharacterController))]
public class HandDetachedMovement : MonoBehaviour
{
    private SimpleCharacterController character;
    private TypeOfDetachable detachable;
    
    public Animator animator;
    public Vector2Variable input;
    public Vector3 moveVector;
    private PushingBoxCollision pushing;
    public Vector3 directionFacing;
    // Start is called before the first frame update
    void Start()
    {
        pushing = GetComponent<PushingBoxCollision>();
        character = GetComponent<SimpleCharacterController>();
        detachable = GetComponent<TypeOfDetachable>();
        //animator = GetComponentInChildren<Animator>();
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
                    directionFacing = new Vector3(moveVector.x, 0, moveVector.z);
                    animator.SetFloat("LastVelY", moveVector.x, 0.1f, Time.deltaTime);
                    //animator.SetFloat("LastVelY", moveVector.x);
                    animator.SetFloat("LastVelZ", moveVector.z, 0.1f, Time.deltaTime);
                    //animator.SetFloat("LastVelZ", moveVector.z);

                    //climbing
                    float clampY = moveVector.x;
                    float clampZ = moveVector.z;
                    if (Mathf.Abs(moveVector.x) > Mathf.Abs(moveVector.z))
                    {
                        clampZ = 0;
                    }
                    else
                    {
                        clampY = 0;
                    }
                    animator.SetFloat("VelocityClampY", clampY);
                    animator.SetFloat("VelocityClampZ", clampZ);
                }
            }
            //Pushing clamping
            //if (pushing.pushing)
            //{
            //    float absX = Mathf.Abs(moveVector.normalized.x);
            //    float absY = Mathf.Abs(moveVector.normalized.z);
            //    if (absX > absY)
            //    {
            //        if (absY < 0.6f) moveVector.z = 0;
            //    }
            //    else
            //    {
            //        if (absX < 0.6f) moveVector.x = 0;
            //    }
            //}
            character.Move(moveVector);
            animator.SetFloat("VelocityY", moveVector.x, 0.1f, Time.deltaTime);
            animator.SetFloat("VelocityZ", moveVector.z, 0.1f, Time.deltaTime);
            //Clamped direction for 
            

            //animator.SetFloat("VelocityY", moveVector.x);
            //animator.SetFloat("VelocityZ", moveVector.z);


        }

    }
    public IEnumerator Climb(float time)
    {
        animator.SetTrigger("Climb");
        yield return new WaitForSeconds(time);
        character.CharacterClimb(directionFacing, 1);
    }
    
}
