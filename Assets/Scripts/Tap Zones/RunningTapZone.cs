using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningTapZone : ATapZone
{
    public override void DoInputAction(float accuracy)
    {
        float speedToadd = calculateSpeedToAddBasedOnAccuracy(accuracy);
        player.AddSpeed(speedToadd);    
    }

    float calculateSpeedToAddBasedOnAccuracy(float accuracy)
    {
        float val = 0;
        if (accuracy <0.5f)
        {
            // fair
            val = 3f;
            Debug.Log("fair");
        }
        else if (accuracy <0.8)
        {
            // good 
            val = 4f;
            Debug.Log("good");
        }
        else
        {
            // perfect
            val = 5f;
            Debug.Log("perfect");
        }
        return val;

    }


}
