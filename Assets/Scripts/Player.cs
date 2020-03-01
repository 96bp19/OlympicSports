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
    [SerializeField] Transform javalineThrowSocket;
    [SerializeField] private float movementLerpSpeed = 1f;
    private bool allowedMoving = true;
    
    [SerializeField] private float lerpedMoveSpeed = 0;
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
        lerpedMoveSpeed = 0;
    }

    public void StartMoving(bool usePreviousVelocity)
    {
        allowedMoving = true;
        if (!usePreviousVelocity)
        {
            ResetPlayerSpeed();
        }
        else
        {
            lerpedMoveSpeed = currentSpeed;
        }
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = defaultMoveSpeed;
        SetDefaultGravityMultiplier();
    }

  
    private void Update()
    {
        movePlayer();
        //CheckGroundDistance();
        Grounded = isGrounded();
        ClampPlayerPos();
     
    }

    void ClampPlayerPos()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = Mathf.Max(playerPos.y, 0.95f);
        transform.position = playerPos;
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
        lerpedMoveSpeed = Mathf.Lerp(lerpedMoveSpeed, currentSpeed, 0.05f);
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

    public bool Grounded;
    public float groundCheckDistance;
    public bool isGrounded()
    {

        Vector3 checkPos = transform.position + raycastOffset;
        Debug.DrawRay(checkPos, Vector3.down * groundCheckDistance, Color.red);
        
        bool grounded = Physics.Raycast(checkPos, Vector3.down, out RaycastHit hitInfo,groundCheckDistance, groundLayer);
        return grounded;
      
       
    }

    public void CheckGroundDistance( )
    {
       
        Vector3 checkPos = transform.position + raycastOffset;
        Debug.DrawRay(checkPos, Vector3.down * 10, Color.red);
        Debug.DrawRay(checkPos, Vector3.down * 10, Color.red);
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, groundLayer))
        {
            Debug.DrawRay(hitInfo.point, Vector3.down * 10, Color.green);
            groundDIstance = Vector3.Distance(checkPos, hitInfo.point);
            
        }
        

    }

    public void AttachToJavalineSocket(Transform obj)
    {
        obj.SetParent(javalineThrowSocket);
        
        obj.transform.localPosition = Vector3.zero;
        obj.localEulerAngles = Vector3.zero;
  

    }

    

    public void SetPlayerSpeed(float speed)
    {

        currentSpeed = speed;
    }

    

}
