using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class DisableVolume : MonoBehaviour
{
    public PostProcessVolume volume;

    private void Start()
    {
        volume.isGlobal = false;
    }

    public void EnableVolume()
    {
        volume.isGlobal = true;
    }

    public void DeactivateVolume()
    {
        volume.isGlobal = false;
    }
}
