using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideRemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RideChecker rider = other.GetComponent<RideChecker>();
            if (rider != null && rider.currentRidable != null)
            {
                rider.Unride();
            }
        }
    }
}
