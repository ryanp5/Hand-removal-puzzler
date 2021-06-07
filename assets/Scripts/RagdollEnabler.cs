using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider capsuleCollider;
    private Rigidbody[] ragdollRigidbodies;
    private Collider[] ragdollcolliders;
    private Animator animator;
    void Awake() 
    {
        animator = GetComponent<Animator>();
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollcolliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
    }
    public void ToggleRagdoll(bool val)
    {
        animator.enabled = !val;
        capsuleCollider.isTrigger = val;
        foreach (Rigidbody r in ragdollRigidbodies)
        {
            r.isKinematic = !val;
        }
        foreach (Collider c in ragdollcolliders)
        {
            c.enabled = val;
        }
        
    }

    
}
