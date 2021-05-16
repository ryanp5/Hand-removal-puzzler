using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBool:MonoBehaviour
{
    private Animator animator;
    public string nameOfBool;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Set(bool value)
    {
        animator.SetBool(nameOfBool, value);
    }
}
