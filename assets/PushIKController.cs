using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushIKController : MonoBehaviour
{
    public HandDetachedMovement movement;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        if (animator)
        {
            if (movement.GetActiveState().GetType() == typeof(ClimbingState)){
                
            }
        }
    }
}
