using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class PhysicalHands : MonoBehaviour
{
    ActionBasedController xrController;
    private void Start()
    {
        xrController = GetComponent<ActionBasedController>();
        //xrController.positionAction.action.
    }
    
}
