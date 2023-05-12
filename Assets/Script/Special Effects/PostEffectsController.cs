using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectsController : MonoBehaviour
{
    public Shader postShader;
    Material postEffectsMaterial;

    //public Color screenTint;
    public float radius;

    private void Awake()
    {
        postEffectsMaterial = new Material(postShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        int width = source.width;   
        int height = source.height;
        
        RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 0, source.format);

        //postEffectsMaterial.SetColor("_ScreenTint", screenTint);
        postEffectsMaterial.SetFloat("_Radius", radius);

        Graphics.Blit(source, renderTexture, postEffectsMaterial, 0);
        Graphics.Blit(renderTexture, destination);

        RenderTexture.ReleaseTemporary(renderTexture);
    }
}