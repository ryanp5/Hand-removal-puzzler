using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRagdollSetter : MonoBehaviour
{
    private ConfigurableJoint joint;

    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }
    void Update()
    {
        
    }
}
