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

    IEnumerator call;
    private void Update()
    {
        movePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {

            System.Action actions = () => Apple(3);

            this.RunFunctionAfter( actions, 2, ref call);
            
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            System.Action actions = () => Apple(1);
            this.CancleFunctionExecution( ref call);

          

           
        }
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
