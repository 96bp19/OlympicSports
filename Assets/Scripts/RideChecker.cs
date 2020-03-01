﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideChecker : MonoBehaviour
{
    private Rideable currentRidable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ride"))
        {
            currentRidable = other.GetComponent<Rideable>();
            other.transform.SetParent(transform);
            Ride(true);
            Vector3 currentPos = transform.position;
            currentPos.y = currentRidable.ridingHeight;
            transform.position = currentPos;
            other.transform.localPosition = Vector3.zero;
        }
    }

    void Ride(bool val)
    {
        GetComponent<Rigidbody>().isKinematic = val;

    }

    public void Unride()
    {
        Ride(false);
        Destroy(currentRidable);
        currentRidable = null;
    }
}