using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractStateController : MonoBehaviour
{
    public bool test = false;
    private BaseStateController controller;
    private void Start()
    {
        controller = GetComponent<BaseStateController>();
    }
    private void Update()
    {
    }
}
