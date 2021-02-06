using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class BoxInteraction : XRGrabInteractable
{
    public LayerMask nothing;
    public LayerMask interactable;

    public void SetUnInteractable()
    {
        interactionLayerMask = nothing;
    }
    public void SetInteractable()
    {
        interactionLayerMask = interactable;
    }
}
