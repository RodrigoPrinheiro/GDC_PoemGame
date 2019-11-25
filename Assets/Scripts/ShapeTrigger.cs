using UnityEngine;

public class ShapeTrigger : MonoBehaviour
{
    private Animator control;
    private bool wasHere;

    private void Start()
    {
        wasHere = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (wasHere) return;

        if (other.tag == "Player")
        {
            control = other.GetComponent<Animator>();
            control.Play("BegoneBall");
            control.Play("GoSquare");
            wasHere = true;
        }
    }
}
