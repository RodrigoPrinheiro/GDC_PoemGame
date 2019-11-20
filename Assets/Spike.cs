using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private Transform _placePos;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerMovement>().ResetSpeed(_placePos.position);
    }
}
