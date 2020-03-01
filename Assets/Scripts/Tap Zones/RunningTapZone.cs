using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public class RunningTapZone : ATapZone
{
    [SerializeField] private float SpeedToAdd  = 2.5f;
    protected virtual void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenTap;
    }

    public  void OnScreenTap()
    {
        if (inputListiningAllowed)
        {
            
            accuracy = CalculatePlayerInputAccuracyWithRespectToDistance(true);
            float speedToadd = calculateSpeedToAddBasedOnAccuracy(accuracy ,SpeedToAdd);
            player.AddSpeed(speedToadd);
           
            CalculateInputReceiveCount();
        }
        
    }

   

    float calculateSpeedToAddBasedOnAccuracy(float accuracy, float baseSpeed)
    {
        return accuracy * baseSpeed;
    }


}
