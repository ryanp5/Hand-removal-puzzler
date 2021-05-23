using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XRRayManager : XRRayInteractor
{       
    protected override void OnDisable()
    {
        if (selectTarget != null)
        {
            selectTarget.gameObject.GetComponent<RotateTransformHandler>().OnDetachReset();
        }
        base.OnDisable();
    }
   
}
