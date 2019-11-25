using UnityEngine;
public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    protected AudioSource sound = default;

    private bool wasHere;

    private void Start()
    {
        wasHere = false;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (wasHere) return;

        if (other.tag == "Player")
        {
            sound.Play();
            wasHere = true;
        }
    }
}
