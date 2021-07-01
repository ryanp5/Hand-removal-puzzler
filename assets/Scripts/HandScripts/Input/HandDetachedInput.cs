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
    private InputAction leftJump;
    private InputAction rightJump;
    public GameEvent leftJumpEvent;
    public GameEvent rightJumpEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (hand == Hand.Right)
        {
            //movement
            RightHandmoveAction = detachedActionMap.AddAction("MoveRightHand", InputActionType.Value);
            RightHandmoveAction.AddBinding("<XRController>{RightHand}/thumbstick");
            RightHandmoveAction.AddBinding("<Gamepad>/rightStick");
        
            RightHandmoveAction.performed += MoveAction_performed;

            // jumping 
            rightJump = detachedActionMap.AddAction("Jump", InputActionType.Button);
            rightJump.AddBinding("<XRController>{RightHand}/primarybutton");
            //rightJump.AddBinding("<Gamepad>/buttonSouth");
            rightJump.performed += RightJump_performed;
        } else if (hand == Hand.Left)
        {
            LeftHandmoveAction = detachedActionMap.AddAction("MoveLeftHand", InputActionType.Value);
            LeftHandmoveAction.AddBinding("<XRController>{LeftHand}/thumbstick");
            LeftHandmoveAction.AddBinding("<Gamepad>/leftStick");

            LeftHandmoveAction.performed += MoveAction_performed;
            //jumping 
            leftJump = detachedActionMap.AddAction("Jump", InputActionType.Button);
            leftJump.AddBinding("<XRController>{LeftHand}/primarybutton");
            leftJump.AddBinding("<Gamepad>/buttonSouth");
            leftJump.performed += LeftJump_performed;
        }
        EnableDetachedInput();
    }

    private void LeftJump_performed(InputAction.CallbackContext obj)
    {
        leftJumpEvent.Raise();
    }

    private void RightJump_performed(InputAction.CallbackContext obj)
    {
        rightJumpEvent.Raise();
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
            rightJump.Disable();
        } else if (hand == Hand.Left)
        {
            LeftHandmoveAction.Disable();
            leftJump.Disable();
        }
        HandInput.value = Vector2.zero;
    }
    public void EnableDetachedInput()
    {
        //Debug.Log("Enabling detached input");
        if (hand == Hand.Right)
        {
            RightHandmoveAction.Enable();
            rightJump.Enable();
        }
        else if (hand == Hand.Left)
        {
            LeftHandmoveAction.Enable();
            leftJump.Enable();
        }
    }
}
