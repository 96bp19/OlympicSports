using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningTapZone : ATapZone
{
    public override void OnScreenTap()
    {
        if (inputListiningAllowed)
        {
            base.OnScreenTap();
            float speedToadd = calculateSpeedToAddBasedOnAccuracy(accuracy);
            player.AddSpeed(speedToadd);
            PlayAnimation();
        }
        
    }

    public override void PlayAnimation()
    {
        animController.IncreaseAnimationSpeed();
    }

    float calculateSpeedToAddBasedOnAccuracy(float accuracy)
    {
        float val = 0;
        if (accuracy <0.5f)
        {
            // fair
            val = 1f;
            Debug.Log("fair");
        }
        else if (accuracy <0.8)
        {
            // good 
            val = 1.8f;
            Debug.Log("good");
        }
        else
        {
            // perfect
            val = 2.5f;
            Debug.Log("perfect");
        }
        return val;

    }


}
