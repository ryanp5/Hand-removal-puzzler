using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.InteractionSubsystems;
using UnityEngine.XR.Interaction.Toolkit;
public class ResetToOrigin : MonoBehaviour
{
    public void SetToOrigin()
    {
        InputTracking.Recenter();
    }
}
