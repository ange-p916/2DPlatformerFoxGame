using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWEffect : MonoBehaviour {

    public float intensity;
    private Material mat;

    private void Awake()
    {
        mat = new Material(Shader.Find("Hidden/BWDiffuse"));
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        if(intensity == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        mat.SetFloat("_bwBlend", intensity);
        Graphics.Blit(source, destination, mat);

    }

}
