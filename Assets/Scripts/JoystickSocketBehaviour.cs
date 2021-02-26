using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoystickSocketBehaviour : XRBaseInteractable
{
    
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        
        //if (interactor is XRGrabInteractable)
        //{
        //    controllerPos = interactor.gameObject.transform;
        //    initalInteractor = (XRGrabInteractable)interactor;
        //    if (interactor.GetComponent<XRController>().controllerNode == XRNode.LeftHand)
        //    {
        //        handPosition = leftHand;
        //    }
        //    else
        //    {
        //        handPosition = rightHand;
        //    }
        //    handPosition.parent = null;
        //    handPosition.position = lockPosition.transform.position;
        //    selected = true;
        //}
        base.OnSelectEntered(interactor);
    }
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
    }
}
