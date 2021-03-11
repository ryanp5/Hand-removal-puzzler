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
    public GameEvent ResetCameraPosition;
    private InputAction RightHandmoveAction;
    public float timeToHold;
    private IEnumerator WaitForHold;
    private void Start()
    {
        RightHandmoveAction = ResetCameraAction.action;
        RightHandmoveAction.started += RightHandmoveAction_started;
        RightHandmoveAction.canceled += RightHandmoveAction_canceled;

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
