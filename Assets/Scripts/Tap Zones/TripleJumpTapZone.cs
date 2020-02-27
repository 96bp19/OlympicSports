using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleJumpTapZone : JumpTapZone
{
    [SerializeField] private float initialtripleJumpTapZonelength =3f;
    float jumpAccuracy;
    bool allowUpdating;
    int currentJumpCount;
    bool checkForJump = false;
    public override void PlayAnimation()
    {

        //animController.TripleJump();
    }
    bool enablejumpAction;

    

    public override void OnScreenTap()
    {
        if (!inputListiningAllowed) return;
        base.OnScreenTap();
        enablejumpAction = true;
        checkForJump = true;
        
       
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
            Debug.Log("anim control is on ground : " + animController.IsOnGround());
            if (animController.IsOnGround() && checkForJump)
            {
                Debug.Log("updating triple jump");
                player.setNewGravityMutiplier(1);
                PlayAnimation();
                player.AddSpeed(2);
                Jump();
                animController.TripleJump(++currentJumpCount);
                checkForJump = false;
                enablejumpAction = false;
                if (currentJumpCount == 3)
                {
                    allowUpdating = false;

                }

            }
           
        }
        else if ((currentJumpCount==1 || currentJumpCount == 2) && animController.IsOnGround())
        {
            framecount++;
         
            if (framecount >10)
            {
                player.StopMoving();
                animController.PlayFoulAnimaiton();
                allowUpdating = false;
            }
        }
       
    }

    bool checkForInitialTap;
    void CheckForInitialTap()
    {
        if (!checkForInitialTap || currentJumpCount >0) return;
        if ((player.transform.position.z-transform.position.z >initialtripleJumpTapZonelength))
        {
            checkForInitialTap = false;
            animController.PlayFoulAnimaiton();
        }
    }





}
