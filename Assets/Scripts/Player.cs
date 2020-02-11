using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float defaultMoveSpeed = 5;
    [SerializeField] float maxMoveSpeed = 25f;
    [SerializeField] float currentSpeed = 0;
    [SerializeField] float defaultGravityMultiplier = 3;
    private float lerpedMoveSpeed = 0;
    private float gravityMultiplier = 3;

    private Vector3 downVector = Vector3.down;
    private Rigidbody rb;

    public Rigidbody getRigidbody()
    {
        return rb;
    }



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = defaultMoveSpeed;
        SetDefaultGravityMultiplier();
    }

    IEnumerator call;
    private void Update()
    {
        movePlayer();
     
    }

   

    void Apple(int x)
    {
        Debug.Log("apple called with val : " + x);
       
    }

    private void FixedUpdate()
    {
        AddNewGravity();
    }
    void movePlayer()
    {
        lerpedMoveSpeed = Mathf.Lerp(lerpedMoveSpeed, currentSpeed, Time.deltaTime * 5);
        transform.position += Vector3.forward * lerpedMoveSpeed *Time.deltaTime;
    }

    public void AddSpeed(float addedSpeed)
    {
        currentSpeed += addedSpeed;
        currentSpeed = Mathf.Clamp(currentSpeed, defaultMoveSpeed, maxMoveSpeed);
    }

    public void ResetPlayerSpeed()
    {
        currentSpeed = defaultMoveSpeed;
    }



   
    public void AddNewGravity()
    {
        rb.AddForce(downVector * 9.8f * gravityMultiplier, ForceMode.Acceleration);
    }

    public void setNewGravityMutiplier(float newGrav)
    {
        gravityMultiplier = newGrav;
    }
    public float getCurrentGravity()
    {
        return 9.8f * gravityMultiplier;
    }

    public void SetDefaultGravityMultiplier()
    {
        gravityMultiplier = defaultGravityMultiplier;
    }

    public float GetCurrentPlayerSpeed()
    {
        return currentSpeed;
    }

    public void StopMoving(bool val)
    {
        if (val)
        {
            currentSpeed = 0;
        }
        else
        {
            ResetPlayerSpeed();
        }
    }

   
}
