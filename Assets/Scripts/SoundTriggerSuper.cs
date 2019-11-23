using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundTriggerSuper : SoundTrigger
{
    public UnityEvent soundEndEvent;
    public UnityEvent soundStartEvent;
    private bool wasPlaying;
    private void Update()
    {
        if (sound.isPlaying)
        {
            wasPlaying = true;
        }

        if (wasPlaying && !sound.isPlaying)
        {
            soundEndEvent?.Invoke();
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
        }

        soundStartEvent?.Invoke();
    }
}
