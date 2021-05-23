using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XRInteractionSetter : MonoBehaviour
{
    private XRRayInteractor RayInteractor;
    // Start is called before the first frame update
    void Start()
    {
        RayInteractor = GetComponent<XRRayInteractor>();
        RayInteractor.enabled = false;
    }

   
}
