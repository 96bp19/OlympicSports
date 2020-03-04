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
            AddScorebasedOnAccuracy(accuracy);
            float speedToadd = calculateSpeedToAddBasedOnAccuracy(accuracy ,SpeedToAdd);
            player.AddSpeed(speedToadd);
            rendererStartPos = new Vector3(0, 0, player.transform.position.z);
            rendererEndPos = new Vector3(0, 0.1f, 0.4f + player.transform.position.z);
            EnableLineRenderer(rendererStartPos,rendererEndPos);
            CalculateInputReceiveCount();

        }
        
    }

   

    float calculateSpeedToAddBasedOnAccuracy(float accuracy, float baseSpeed)
    {
        return accuracy * baseSpeed;
    }


}
