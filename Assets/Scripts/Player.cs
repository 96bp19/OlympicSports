using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float defaultMoveSpeed = 5;
    [SerializeField] float maxMoveSpeed = 25f;
    [SerializeField] float currentSpeed = 0;
    [SerializeField] float defaultGravityMultiplier = 3;
    [SerializeField] float jumpHeight;
    private bool allowedMoving = true;
    
    private float lerpedMoveSpeed = 0;
    private float gravityMultiplier = 3;

    private Vector3 downVector = Vector3.down;
    private Rigidbody rb;

    public Rigidbody getRigidbody()
    {
        return rb;
    }

    public void StopMoving()
    {
        allowedMoving = false;
    }

    public void StartMoving(bool usePreviousVelocity)
    {
        allowedMoving = true;
        if (!usePreviousVelocity)
        {
            ResetPlayerSpeed();
        }
        
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
        CheckGroundDistance();
     
    }

   
    private void FixedUpdate()
    {
        AddNewGravity();
    }
    void movePlayer()
    {
        if (!allowedMoving)
        {
            return;
        }
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
        allowedMoving = true;
        
        
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

    public void Jump(float jumpheight =0)
    {
        float yvel = YVel(jumpheight);
        if (jumpheight == 0)
        {
            yvel = YVel(jumpHeight);
        }

        rb.velocity = new Vector3(rb.velocity.x, yvel, rb.velocity.z);
       
    }

    private float YVel( float height)
    {  
            return Mathf.Sqrt(Mathf.Abs(getCurrentGravity() * height * 2f));        
    }


    [SerializeField] private Vector3 raycastOffset;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDIstance;
    bool startCheckingInput;
    public void CheckGroundDistance( )
    {
        Vector3 checkPos = transform.position + raycastOffset;
        Debug.DrawRay(checkPos, Vector3.down * 10, Color.red);
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, groundLayer))
        {
            Debug.DrawRay(hitInfo.point, Vector3.down * 10, Color.green);
            groundDIstance = Vector3.Distance(checkPos, hitInfo.point);
            
        }
        

    }
    

}
