using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public class TripleJumpTapZone : JumpTapZone
{
    [SerializeField] private float initialTapLength =3f;
    float jumpAccuracy;
    bool allowUpdating;
    int currentJumpCount;
    bool checkForJump = false;
    bool enablejumpAction;
    
    float distanceTraveled = 0;

    [SerializeField] float inputBufferForJump=2f;
    private float currentInputTime;

    float scaleZ, startZ;

    private  void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenTap;
        scaleZ = transform.localScale.z;
        startZ = transform.position.z + initialTapLength;
    }

    public  void OnScreenTap()
    {
        if (!inputListiningAllowed) return;        
        if (!enablejumpAction)
        {
            checkForJump = true;
            enablejumpAction = true;
            currentInputTime = inputBufferForJump;
            rendererStartPos.z = player.transform.position.z;

        }  
    }

    protected override void OnTriggerEnter(Collider other)
    {
        
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            allowUpdating = true;
            checkForInitialTap = true;
        }
    }

  

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        allowUpdating = false;
    }

    int framecount;
    private void Update()
    {
        CheckForInitialTap();
        CheckForMeterTravel();
        
        if (!allowUpdating)
        {

            return;
        }
        if ( enablejumpAction)
        {
            CheckForInputBufferMiss();
            if (animController.IsOnGround() && checkForJump)
            {
                //Debug.log("updating triple jump");
                player.setNewGravityMutiplier(1);
                rendererEndPos.z = player.transform.position.z;
                EnableLineRenderer(rendererStartPos, rendererEndPos);
                Jump();
                AddScorebasedOnAccuracy(accuracy);
                animController.TripleJump(++currentJumpCount);
                checkForJump = false;
                enablejumpAction = false;
               
                player.AddSpeed(MeasureSpeedBasedOnAccuracy(2));
                CalculateInputReceiveCount();
                if (currentJumpCount == 3)
                {
                    timeSpent = 1f;
                    allowUpdating = false;

                }
                framecount = 0;

            }
           
        }
        else if ((currentJumpCount==1 || currentJumpCount == 2) && animController.IsOnGround())
        {
            framecount++;
            //currentInputTime = 0.01f;
            if (framecount >10)
            {
                player.StopMoving(false);
                animController.PlayFoulAnimaiton();
                allowUpdating = false;
            }
        }

       
       
    }

    void CheckForInputBufferMiss()
    {
        currentInputTime -= Time.deltaTime;
        if (currentInputTime <0)
        {
            enablejumpAction = false;
        }
    }

    bool checkForInitialTap;
    void CheckForInitialTap()
    {
        if (!checkForInitialTap || currentJumpCount >0) return;
        if ((player.transform.position.z-transform.position.z >initialTapLength))
        {
            checkForInitialTap = false;
            animController.PlayFoulAnimaiton();
        }
    }

    float CalculateAccuracy(float currentval , float maxval)
    {
        return currentval / maxval;

    }

    float MeasureSpeedBasedOnAccuracy(float baseMoveSpeed)
    {
      
        if (currentJumpCount ==1)
        {
            accuracy = (initialTapLength-(player.transform.position.z - transform.position.z)) / initialTapLength;
        }
        else if (framecount >2)
        {
            accuracy = Random.Range(0, 0.8f);
        }
        else
        {
            //Debug.log("time accuracy");
            accuracy = CalculateAccuracy(currentInputTime, inputBufferForJump*1.5f);
        }
        framecount = 0;
        //Debug.log("accurcay : " + accuracy );
        return accuracy * baseMoveSpeed;

    }

    // hacky solution for now 
    float timeSpent;  // this needs to be removed later when better solution is found
    void CheckForMeterTravel()
    {


        if (currentJumpCount >0 && currentJumpCount <=3)
        {
            distanceTraveled = GameManager.PlayerInstance.transform.position.z - startZ;
            distanceTraveled = Mathf.Max(0, distanceTraveled);
            GameManager.UIManager_Instance.StartUpdatigMeterTravel(true, distanceTraveled);

        }
        if (currentJumpCount == 3)
        {
            timeSpent -= Time.deltaTime;
        }

        if (timeSpent <=0 && GameManager.PlayerInstance.isGrounded() && currentJumpCount ==3)
        {
            
            GameManager.UIManager_Instance.StartUpdatigMeterTravel(false, distanceTraveled);
            currentJumpCount = 4;
            

        }
    }





}
