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
        allowUpdating = true;
       
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    private void Update()
    {
        if (!allowUpdating)
        {
            return;
        }
        if (animController.IsOnGround() )
        {
            player.setNewGravityMutiplier(1);
            PlayAnimation();
            player.AddSpeed(2);
            base.DoInputAction(jumpAccuracy);
            allowUpdating = false;
        }
    }





}
