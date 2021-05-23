using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public enum Hand { Left, Right};
public class HandDetachedInput : MonoBehaviour
{
    public Hand hand;
    private ActionBasedController controller;
    public InputActionMap detachedActionMap = new InputActionMap("Detached");
    public Vector2Variable HandInput;
    private InputAction RightHandmoveAction;
    private InputAction LeftHandmoveAction;
    
    // Start is called before the first frame update
    void Start()
    {
        if (hand == Hand.Right)
        {
            RightHandmoveAction = detachedActionMap.AddAction("MoveRightHand", InputActionType.Value);
            RightHandmoveAction.AddBinding("<XRController>{RightHand}/thumbstick");
            RightHandmoveAction.AddBinding("<Gamepad>/rightStick");
            RightHandmoveAction.performed += MoveAction_performed;
        } else if (hand == Hand.Left)
        {
            LeftHandmoveAction = detachedActionMap.AddAction("MoveLeftHand", InputActionType.Value);
            LeftHandmoveAction.AddBinding("<XRController>{LeftHand}/thumbstick");
            LeftHandmoveAction.performed += MoveAction_performed;
        }
        EnableDetachedInput();
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        HandInput.value = obj.ReadValue<Vector2>();
    }
    public void DisableDetachedInput()
    {
        //Debug.Log("Disabling detached input");
        if (hand == Hand.Right)
        {
            RightHandmoveAction.Disable();
        } else if (hand == Hand.Left)
        {
            LeftHandmoveAction.Disable();

        }
        HandInput.value = Vector2.zero;
    }
    public void EnableDetachedInput()
    {
        //Debug.Log("Enabling detached input");
        if (hand == Hand.Right)
        {
            RightHandmoveAction.Enable();
        }
        else if (hand == Hand.Left)
        {
            LeftHandmoveAction.Enable();

        }
    }
}
