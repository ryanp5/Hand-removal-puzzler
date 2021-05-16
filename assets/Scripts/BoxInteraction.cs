using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class BoxInteraction : XRGrabInteractable
{
    public LayerMask interactableMask;
    public LayerMask nothing;
    public int interactable;
    public int Uninteractable;

    public void SetUnInteractable()
    {
        interactionLayerMask = nothing;
        gameObject.layer = Uninteractable;
    }
    public void SetInteractable()
    {
        interactionLayerMask = interactionLayerMask;
        gameObject.layer = interactable;
    }
}
