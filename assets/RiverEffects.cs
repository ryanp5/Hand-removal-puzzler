using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverEffects : MonoBehaviour
{
    public float riverStrength;
    public LayerMask layerMask;
    private void OnTriggerStay(Collider other)
    {
        if (layerMask == (layerMask | 1<< other.gameObject.layer))
        {
            other.attachedRigidbody.velocity = new Vector3(riverStrength * -1, -0.5f, 0);
            //other.transform.position
            
        }
    }
}
