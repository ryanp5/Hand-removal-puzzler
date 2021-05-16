using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FadeRenderPass : ScriptableRenderPass
{
    private FadeRenderFeature.FadeSettings settings;
    public FadeRenderPass(FadeRenderFeature.FadeSettings newSettings)
    {
        settings = newSettings;
        renderPassEvent = newSettings.WhenToInsert;
        
    }
    public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
    {
        base.Configure(cmd, cameraTextureDescriptor);
    }
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        CommandBuffer command = CommandBufferPool.Get(settings.profilerTag);
        command.Clear();
        RenderTargetIdentifier source = BuiltinRenderTextureType.CameraTarget;
        RenderTargetIdentifier destination = BuiltinRenderTextureType.CurrentActive;

        command.Blit(source, destination, settings.RunTimematerial);
        context.ExecuteCommandBuffer(command);

        command.Clear();
        CommandBufferPool.Release(command);
    }
}
