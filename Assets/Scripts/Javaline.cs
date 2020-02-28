using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javaline : MonoBehaviour
{

    Vector3 javalineThrowPos;
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
        CameraManager.Instance.FollowJavaline(transform);
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
            GameManager.UIManager_Instance.DisableUpdatingJavalineThrow();
            
            calculateDistanceStart = false;
            GetComponent<Rigidbody>().isKinematic = true;
            startUpdatingUpdate = false;
            Invoke("DestroyJavaline", 2f);
        }
       
        if (calculateDistanceStart)
        {
            Debug.Log("javaline start pos : " + javalineThrowPos);
            currentDistance = transform.position.z - javalineThrowPos.z;
            currentDistance = Mathf.Clamp(currentDistance, 0, float.MaxValue);
            GameManager.UIManager_Instance.SetJavalineMeterTravel(currentDistance);
        }

        if (!rb.isKinematic)
        {
            Quaternion rot = Quaternion.LookRotation(rb.velocity.normalized);
            transform.rotation = rot;


        }
    }

    // target is who ever throws this javalin
    // target here is used to calculate the distance between the javalin and thrower
    public void SetjavalineStartPos(Vector3 javalineThrowStartPos)
    {
        javalineThrowPos = javalineThrowStartPos;
        calculateDistanceStart = true;
        
    }

    void DestroyJavaline()
    {
        CameraManager.Instance.FollowPlayer();
        Destroy(this.gameObject);
    }
}
