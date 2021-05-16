using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftHandXRInput : ActionBasedController
{
    [SerializeField]
    InputActionProperty ReturnToMenuAction;
    [SerializeField]
    InputActionProperty LeftHandGripActionProperty;
    public FloatVariable GripValue;
    public GameSceneManager sceneManager;
    private InputAction LeftHandMoveAction;
    private InputAction LeftHandGripAction;

    private IEnumerator WaitForHold;
    public float timeToHold;

    private void Start()
    {
        LeftHandMoveAction = ReturnToMenuAction.action;
        LeftHandMoveAction.started += LeftHandmoveAction_started;
        LeftHandMoveAction.canceled += LeftHandmoveAction_canceled;
        //grip action
        LeftHandGripAction = LeftHandGripActionProperty.action;
        LeftHandGripAction.performed += LeftHandGripAction_performed;
    }

    private void LeftHandGripAction_performed(InputAction.CallbackContext obj)
    {
        GripValue.value = obj.ReadValue<float>();
    }

    public void HapticFeedBack(float time)
    {
        SendHapticImpulse(0.1f, time);
    }
    private void LeftHandmoveAction_canceled(InputAction.CallbackContext obj)
    {
        StopCoroutine(WaitForHold);
    }
    private void LeftHandmoveAction_started(InputAction.CallbackContext obj)
    {
        WaitForHold = Wait(timeToHold);
        StartCoroutine(WaitForHold);
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Returning to menu");
        sceneManager.LoadMainMenu();
    }
}
