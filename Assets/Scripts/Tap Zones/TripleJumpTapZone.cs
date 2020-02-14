using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleJumpTapZone : JumpTapZone
{

    float jumpAccuracy;
    bool allowUpdating;
    public override void PlayAnimation()
    {

        animController.TripleJump();
    }
    bool enablejumpAction;

    public override void DoInputAction(float accuracy)
    {
        jumpAccuracy = accuracy;
        enablejumpAction = true;
       
      
       
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        allowUpdating = true;
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        allowUpdating = false;
    }

    int framecount;
    private void Update()
    {
        if (!allowUpdating)
        {

            return;
        }
        if ( enablejumpAction)
        {
            Debug.Log("anim control is on ground : " + animController.IsOnGround());
            if (animController.IsOnGround())
            {
                Debug.Log("updating triple jump");
                player.setNewGravityMutiplier(1);
                PlayAnimation();
                player.AddSpeed(2);
                base.DoInputAction(jumpAccuracy);
                allowUpdating = false;

            }
           
        }
        else if ((animController.getCurrentTripleJumpIndex() ==1 || animController.getCurrentTripleJumpIndex() ==2) && animController.IsOnGround())
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





}
