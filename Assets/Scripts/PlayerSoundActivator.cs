using UnityEngine;

public class PlayerSoundActivator : MonoBehaviour
{
    private CharacterController _cc;
    private AudioSource _source;
    private bool wasOnGround;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        _cc = GetComponent<CharacterController>();
        wasOnGround = true;
    }

    void FixedUpdate()
    {
        if (_cc.isGrounded && !wasOnGround)
        {
            _source.Play();
        }

        wasOnGround = _cc.isGrounded;
    }
}
