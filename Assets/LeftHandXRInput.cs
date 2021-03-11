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
    public GameSceneManager sceneManager;
    private InputAction LeftHandMoveACtion;
    private IEnumerator WaitForHold;
    public float timeToHold;

    private void Start()
    {
        LeftHandMoveACtion = ReturnToMenuAction.action;
        LeftHandMoveACtion.started += LeftHandmoveAction_started;
        LeftHandMoveACtion.canceled += LeftHandmoveAction_canceled;

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
