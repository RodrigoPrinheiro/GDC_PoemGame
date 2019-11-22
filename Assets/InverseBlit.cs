using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseBlit : MonoBehaviour
{
    public Material TransitionMaterial;

    private bool shouldBlit;

    private void Start()
    {
        shouldBlit = false;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (TransitionMaterial != null && shouldBlit)
            Graphics.Blit(src, dst, TransitionMaterial);
    }

    public void AddInvert()
    {
        shouldBlit = true;
    }
}
