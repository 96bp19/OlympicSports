using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTapZone : JumpTapZone
{

    public override void OnScreenTap()
    {
        if (!inputListiningAllowed) return;
        base.OnScreenTap();
        player.SetDefaultGravityMultiplier();
        player.ResetPlayerSpeed();
        jumpHeight = calculateJumpheightBasedOnAccuracy(accuracy);
        PlayAnimation();
        Jump();
    }

    public override void PlayAnimation()
    {
        animController.HighJump();
    }

    float calculateJumpheightBasedOnAccuracy(float accuracy)
    {
        float val = 0;
        if (accuracy < 0.5f)
        {
            // fair
            val = 2.5f;
            Debug.Log("fair");
        }
        else if (accuracy < 0.8)
        {
            // good 
            val = 3f;
            Debug.Log("good");
        }
        else
        {
            // perfect
            val = 3.5f;
            Debug.Log("perfect");
        }
        return val;

    }

    


}
