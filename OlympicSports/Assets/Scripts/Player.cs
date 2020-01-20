using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;
    [SerializeField] float currentSpeed = 0;

    private Rigidbody rb;
    public Rigidbody getRigidbody()
    {
        return rb;
    }



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        transform.position += transform.forward * currentSpeed *Time.deltaTime;
    }

    public void AddSpeed(float addedSpeed)
    {
        currentSpeed += addedSpeed;
    }

    public void ResetPlayer()
    {
        currentSpeed = moveSpeed;
    }

   
}
