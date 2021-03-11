using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderType : MonoBehaviour
{
    public Material mat;
    private void Start()
    {
        mat.SetInt("_SurfaceType", 1);
        mat.SetInt("_RenderQueueType", 4);
        mat.SetInt("_SurfaceType", 1);

    }
}
