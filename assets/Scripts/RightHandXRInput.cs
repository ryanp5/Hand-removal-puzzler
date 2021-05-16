using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandXRInput : ActionBasedController
{
    [SerializeField]
    InputActionProperty ResetCameraAction;
    [SerializeField]
    InputActionProperty RightHandGripActionProperty;
    public GameEvent ResetCameraPosition;
    public GameEvent RightHandGrip;
    public FloatVariable GripValue;
    private InputAction RightHandmoveAction;
    private InputAction RightHandGripAction;
    public float timeToHold;
    private IEnumerator WaitForHold;
    private void Start()
    {
        //Reset camera action
        RightHandmoveAction = ResetCameraAction.action;
        RightHandmoveAction.started += RightHandmoveAction_started;
        RightHandmoveAction.canceled += RightHandmoveAction_canceled;
        //gripping value interaction
        RightHandGripAction = RightHandGripActionProperty.action;
        RightHandGripAction.performed += RightHandGripAction_performed;

    }

    private void RightHandGripAction_performed(InputAction.CallbackContext obj)
    {
        GripValue.value = obj.ReadValue<float>();
    }

    private void RightHandmoveAction_canceled(InputAction.CallbackContext obj)
    {
        StopCoroutine(WaitForHold);
    }

    public void HapticFeedBack(float time)
    {
        SendHapticImpulse(0.1f, time);
    }
    private void RightHandmoveAction_started(InputAction.CallbackContext obj)
    {
        WaitForHold = Wait(timeToHold);
        StartCoroutine(WaitForHold);
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Camera reset");
        ResetCameraPosition.Raise();
    }
}
