using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioSource sound = default;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
        }
    }
}
