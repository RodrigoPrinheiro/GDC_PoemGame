using UnityEngine;

public class ShapeTrigger : MonoBehaviour
{
    private Animator control;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            control = other.GetComponent<Animator>();
            control.Play("BegoneBall");
            control.Play("GoSquare");
        }
    }
}
