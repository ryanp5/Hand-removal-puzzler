using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandDetachedInput : MonoBehaviour
{
    private ActionBasedController controller;
    public InputActionMap detachedActionMap = new InputActionMap("Detached");
    public Vector2Variable RightHandInput;
    private InputAction moveAction;
    // Start is called before the first frame update
    void Start()
    {
        moveAction = detachedActionMap.AddAction("Move",InputActionType.Value);
        
        moveAction.AddBinding("<XRController>{RightHand}/thumbstick");
        moveAction.AddBinding("<Gamepad>/leftStick");
        moveAction.performed += MoveAction_performed;
        controller = GetComponentInParent<ActionBasedController>();
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        RightHandInput.value = obj.ReadValue<Vector2>();
    }
    public void DisableDetachedInput()
    {
        Debug.Log("Disabling detached input");
        moveAction.Disable();
        RightHandInput.value = Vector2.zero;
    }
    public void EnableDetachedInput()
    {
        Debug.Log("Enabling detached input");
        moveAction.Enable();
    }
}
