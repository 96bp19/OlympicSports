using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longJumpTapZone : JumpTapZone
{
    private bool screenHoldStarted = false;
    private float startAccuracy = 0;
    public override void DoInputAction(float accuracy)
    {
         player.setNewGravityMutiplier(1);
        //base.DoInputAction(accuracy);
        startAccuracy = accuracy;
        screenHoldStarted = true;
        player.ResetPlayerSpeed();
        GameManager.UIManager_Instance.EnableHoldMeter(true);
    }

    private void Update()
    {
        if ( screenHoldStarted)
        {

            if (player)
            {
                UpdatePlayerSpeed();
                GameManager.UIManager_Instance.UpdateHoldMeterVal(CalculatePlayerInputAccuracyWithRespectToDistance() - startAccuracy + 0.1f);

                if (!GameManager.InputManagerInstance.getInputData().screenHold)
                {
                    screenHoldStarted = false;
                
                    // in case of long jump accuracy is not required as parameter 
                    // because it has already been calculated , so 1 used here is random value
                    // we can use any thing it does not matter
                    base.DoInputAction(1);

            
                }

            }
            else
            {
                Debug.Log("foul");
                screenHoldStarted = false;
            }
        }
    }

    void UpdatePlayerSpeed()
    {
        player.AddSpeed(Time.fixedDeltaTime*5);
    }
}
