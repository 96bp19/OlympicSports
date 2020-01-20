using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javaline : MonoBehaviour
{

    Transform target;
    bool calculateDistanceStart;
    public float currentDistance;
    void Update()
    {
        if (transform.position.y <1f)
        {
            calculateDistanceStart = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
       
        if (calculateDistanceStart)
        {
            currentDistance = Mathf.Abs(target.transform.position.z - transform.position.z);
        }

        if (!GetComponent<Rigidbody>().isKinematic)
        {
            Quaternion rot = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity.normalized);
            transform.rotation = rot;

        }
    }

    public void setTarget(Transform target)
    {
        this.target = target;
        calculateDistanceStart = true;
    }
}
