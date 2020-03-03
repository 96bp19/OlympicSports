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

    [SerializeField] float inputBufferForJump=2f;
    private float currentInputTime;

    private  void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenTap;
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
        if (!allowUpdating)
        {

            return;
        }
        if ( enablejumpAction)
        {
            CheckForInputBufferMiss();

            if (animController.IsOnGround() && checkForJump)
            {
                Debug.Log("updating triple jump");
                player.setNewGravityMutiplier(1);
                rendererEndPos.z = player.transform.position.z;
                EnableLineRenderer(rendererStartPos, rendererEndPos);
                Jump();
                animController.TripleJump(++currentJumpCount);
                checkForJump = false;
                enablejumpAction = false;
               
                player.AddSpeed(MeasureSpeedBasedOnAccuracy(1));
                CalculateInputReceiveCount();
                if (currentJumpCount == 3)
                {
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
                player.StopMoving();
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
            accuracy = 0.1f;
        }
        else
        {
            Debug.Log("time accuracy");
            accuracy = CalculateAccuracy(currentInputTime, inputBufferForJump);
        }
        framecount = 0;
        Debug.Log("accurcay : " + accuracy );
        return accuracy * baseMoveSpeed + baseMoveSpeed;

    }





}
