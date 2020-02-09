﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJumpTapZone : JumpTapZone
{

    float Playeraccuracy;
    public override void DoInputAction(float accuracy)
    {
        this.Playeraccuracy = accuracy;
       // player.SetDefaultGravityMultiplier();
        //base.DoInputAction(accuracy);

    }


    public override void PlayAnimation(AnimationController animController)
    {
        animController.HurdleJump();
        player.SetDefaultGravityMultiplier();
        Invoke("JumpAfterDelay", 0.02f);
        
    }

    void JumpAfterDelay()
    {
        Debug.Log("jump delayed");
        base.DoInputAction(Playeraccuracy);

    }
}