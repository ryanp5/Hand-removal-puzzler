using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseLowerTwoButton : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 finishPt;
    public int buttonCount;
    public List<bool> cond = new List<bool>();
    float distance;
    private void Start()
    {
        origin = transform.position;
        distance = (finishPt.y - origin.y)/ buttonCount;
        for (int i = 0; i < buttonCount; i++)
        {
            cond.Add(false);
        }
    }
    private void Update()
    {
        float step = Time.deltaTime * 1.0f;
        int num = 0;
        for (int i = 0; i < buttonCount; i++)
        {
            if (cond[i])
            {
                num++;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,origin.y + distance*num,transform.position.z), step);
        
        //transform.position = Vector3.MoveTowards(transform.position, origin, step);
        
    }
    public void RaisePlatform(int index)
    {
        cond[index] = true;
    }
    public void LowerPlatform(int index)
    {
        cond[index] = false;
    }

}
