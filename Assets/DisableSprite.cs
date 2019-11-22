using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSprite : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
