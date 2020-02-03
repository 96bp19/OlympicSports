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

        if (!GetComponent<Rigidbody>().isKinematic)
        {
            Quaternion rot = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity.normalized);
            transform.rotation = rot;

        }
    }

    // target is who ever thorws this javalin
    // target here is used to calculate the distance between the javalin and thrower
    public void setTarget(Transform target)
    {
        this.target = target;
        calculateDistanceStart = true;
    }
}
