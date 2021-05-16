using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadeRenderFeature : ScriptableRendererFeature
{
    [Serializable]
    
    public class FadeSettings
    {
        public string profilerTag;
        public bool IsEnabled = true;
        public RenderPassEvent WhenToInsert = RenderPassEvent.AfterRenderingPostProcessing;
        public Material material; 
        [NonSerialized]public Material RunTimematerial = null; 
        public bool AreValid()
        {
            return (RunTimematerial != null) && IsEnabled;
        }
    }
    public FadeSettings settings = new FadeSettings();

    RenderTargetHandle renderTargetHandle;
    FadeRenderPass renderPass;
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        //if (!settings.IsEnabled)
        //{
        //    return;
        //}
        if (settings.AreValid())
            renderer.EnqueuePass(renderPass);
    }

    public override void Create()
    {
        renderPass = new FadeRenderPass(settings);
    }
}
