using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleCharacterController))]
public class HandDetachedMovement : MonoBehaviour
{
    private SimpleCharacterController character;
    private TypeOfDetachable detachable;
    
    public Vector2Variable input;
    Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<SimpleCharacterController>();
        detachable = GetComponent<TypeOfDetachable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!detachable.attached)
        {
            moveVector = Vector3.zero;
            if (!character.isGrounded)
            {
                //moveVector = Physics.gravity;
            }
            else
            {
                moveVector = new Vector3(input.value.y, 0, -input.value.x);
            }
            character.Move(moveVector);
        }
    }
}
