using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCountEnabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeCalculator.Instance.StartTimeCount();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeCalculator.Instance.StopTimeCount();
        }
    }
}
