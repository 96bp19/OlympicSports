using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTapZone : JumpTapZone
{
    public override void DoInputAction(float accuracy)
    {
        player.SetDefaultGravityMultiplier();
        player.ResetPlayerSpeed();
        jumpHeight = calculateJumpheightBasedOnAccuracy(accuracy);
        base.DoInputAction(accuracy);
       
        
    }

    float calculateJumpheightBasedOnAccuracy(float accuracy)
    {
        float val = 0;
        if (accuracy < 0.5f)
        {
            // fair
            val = 8f;
            Debug.Log("fair");
        }
        else if (accuracy < 0.8)
        {
            // good 
            val = 10f;
            Debug.Log("good");
        }
        else
        {
            // perfect
            val = 12f;
            Debug.Log("perfect");
        }
        return val;

    }


}
