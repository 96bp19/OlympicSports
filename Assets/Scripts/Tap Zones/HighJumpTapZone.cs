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
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance(true);
        player.SetDefaultGravityMultiplier();
        player.ResetPlayerSpeed();
        rendererStartPos = new Vector3(0, 0, player.transform.position.z);
        rendererEndPos = new Vector3(0, 0.1f, 0.4f + player.transform.position.z);
        EnableLineRenderer(rendererStartPos, rendererEndPos);
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
