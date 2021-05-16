
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloat : MonoBehaviour
{
    [Serializable]
    public class NameValues
    {
        public string name;
        public float value;
    }
    private Animator animator;
    public List<NameValues> names = new List<NameValues>();
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Set(int id)
    {
        if (names[id] != null)
        {
            animator.SetFloat(names[id].name, names[id].value);
        }
    }

}
