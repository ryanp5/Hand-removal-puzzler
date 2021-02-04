using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
/// <summary>
/// Code taken from
/// https://www.youtube.com/watch?v=SqMxKYYWyYk&ab_channel=VRwithAndrew
/// </summary>
public class HandButton : XRBaseInteractable
{
    public GameEvent onPress;
    public GameEvent onUnPress;
    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previousPress = false;
    private float previousHandHeight = 0.0f;
    private XRBaseInteractor hoverInteractor = null;

    protected override void Awake()
    {
        base.Awake();
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
    }
    private void Start()
    {
        SetMinMax();
    }

    private void EndPress(XRBaseInteractor intereactor)
    {
        hoverInteractor = null;
        previousHandHeight = 0.0f;
        previousPress = false;
        SetYPosition(yMax);
    }

    private void StartPress(XRBaseInteractor interactor)
    {
        hoverInteractor = interactor;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
    }
    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y *0.5f);
        yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (hoverInteractor)
        {
            float newHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);
            CheckPress();
        }
    }
    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);
        return localPosition.y;
    }
    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, yMin, yMax);
        transform.localPosition = newPosition;
    }
    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previousPress)
        {
            onPress.Raise();
        }
        previousPress = inPosition;
    }
    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);
        return transform.localPosition.y ==inRange;
    }
}
