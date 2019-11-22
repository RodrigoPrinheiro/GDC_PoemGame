using UnityEngine;
public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    protected AudioSource sound = default;
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
            Destroy(gameObject);
        }
    }
}
