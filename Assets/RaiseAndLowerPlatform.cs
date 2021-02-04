using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseAndLowerPlatform : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 finishPt;
    public bool bridgeUp;
    private void Start()
    {
        origin = transform.position;
    }
    private void Update()
    {
        float step = Time.deltaTime * 1.0f;
        if (bridgeUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, finishPt, step);
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, step);
        }
    }
    public void RaisePlatform()
    {
        bridgeUp = true;
    }
    public void LowerPlatform()
    {
        bridgeUp = false;
    }

}
