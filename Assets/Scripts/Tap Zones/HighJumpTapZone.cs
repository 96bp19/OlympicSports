using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;
public class HighJumpTapZone : JumpTapZone
{

    private void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenTap;
    }

    public void OnScreenTap()
    {
        if (!inputListiningAllowed) return;

        CalculateInputReceiveCount();
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance();
        player.SetDefaultGravityMultiplier();
        player.ResetPlayerSpeed();
        float heightForjump = calculateJumpheightBasedOnAccuracy(accuracy);
        PlayAnimation();
        Jump();
    }

    public void PlayAnimation()
    {
        animController.HighJump();
    }

    float calculateJumpheightBasedOnAccuracy(float accuracy)
    {

        return accuracy * jumpHeight;

    }

    


}
