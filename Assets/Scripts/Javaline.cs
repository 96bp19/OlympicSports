using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javaline : MonoBehaviour
{

    Transform target;
    bool calculateDistanceStart;
    public float currentDistance;
    bool startUpdatingUpdate = false;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ThrowJavaline()
    {
        startUpdatingUpdate = true;
    }
    void Update()
    {
        if (startUpdatingUpdate == false)
        {
            return;
        }
        // this is calculated to know if the javalin has landed on ground
        // will use different approach later this is temp approach
        if (transform.position.y <1f)
        {
            calculateDistanceStart = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
       
        if (calculateDistanceStart)
        {
            currentDistance = Mathf.Abs(target.transform.position.z - transform.position.z);
        }

        if (!rb.isKinematic)
        {
            Quaternion rot = Quaternion.LookRotation(rb.velocity.normalized);
            transform.rotation = rot;


        }
    }

    // target is who ever throws this javalin
    // target here is used to calculate the distance between the javalin and thrower
    public void setTarget(Transform target)
    {
       
        this.target = target;
        calculateDistanceStart = true;
        
    }
}
