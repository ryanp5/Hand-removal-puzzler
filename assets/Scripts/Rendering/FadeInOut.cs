using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadeInOut : MonoBehaviour
{
    public ForwardRendererData rendererData;
    private Material fadeMat = null;
    [Range(0.0f,1.0f)]
    public float alpha = 0.0f;
    public float duration = 1.0f;

    private void Start()
    {
        foreach (ScriptableRendererFeature feature in rendererData.rendererFeatures)
        {
            if (feature is FadeRenderFeature screenFade)
            {
                FadeRenderFeature fadeRender = (FadeRenderFeature)feature;
                fadeMat = Instantiate(fadeRender.settings.material);
                screenFade.settings.RunTimematerial = fadeMat;
            }
        }
    }

    public void FadeIn()
    {
        StartCoroutine(LerpForTime(0.0f, 1.0f, duration));
    }
    public void Fadeout()
    {
        StartCoroutine(LerpForTime(1.0f, 0.0f, duration));
    }
    public IEnumerator LerpForTime(float start, float end, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            alpha = Mathf.Lerp(start, end, timeElapsed / duration);
            fadeMat.SetFloat("Vector1_alpha", alpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        alpha = end;
        fadeMat.SetFloat("Vector1_alpha", alpha);
    }
}
