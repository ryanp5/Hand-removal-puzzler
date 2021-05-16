using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GrabIkController : MonoBehaviour
{
    private Animator animator;
    public Transform leftHandTarget;
    public Transform rightHandTarget;
    public FloatVariable gripValue;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
   
    void OnAnimatorIK()
    {
        if (animator)
        {
            if (animator.GetBool("Attached"))
            {
               
                if (rightHandTarget != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, gripValue.value);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, gripValue.value);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
                }
                if (leftHandTarget != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, gripValue.value);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, gripValue.value);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
                }
            }
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
    }
}
