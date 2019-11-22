using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextTrigger : MonoBehaviour
{
    public UnityEvent textEvent;

    private bool wasUsed;

    private void Start()
    {
        wasUsed = false;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (wasUsed) return;

        wasUsed = true;
        textEvent?.Invoke();
    }
}
