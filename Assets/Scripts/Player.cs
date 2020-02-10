using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;
    [SerializeField] float currentSpeed = 0;
    [SerializeField] float defaultGravityMultiplier = 3;
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
        currentSpeed = moveSpeed;
        SetDefaultGravityMultiplier();
    }

    private void Update()
    {
        movePlayer();
    }

    private void FixedUpdate()
    {
        AddNewGravity();
    }
    void movePlayer()
    {
        transform.position += Vector3.forward * currentSpeed *Time.deltaTime;
    }

    public void AddSpeed(float addedSpeed)
    {
        currentSpeed += addedSpeed;
    }

    public void ResetPlayerSpeed()
    {
        currentSpeed = moveSpeed;
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

   
}
