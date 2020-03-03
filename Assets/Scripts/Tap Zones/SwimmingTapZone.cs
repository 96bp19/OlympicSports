using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Binaya.MyInput;

public class SwimmingTapZone : JumpTapZone
{

    private void Start()
    {
        MobileInputManager.Instance.ScreenHoldStartListener += OnScreenTap;
    }

    public  void OnScreenTap()
    {
        if (!inputListiningAllowed) return;
        CalculateInputReceiveCount();
        accuracy = CalculatePlayerInputAccuracyWithRespectToDistance(true);
        rendererStartPos = new Vector3(0, 0, player.transform.position.z);
        rendererEndPos = new Vector3(0, 0.1f, 0.4f + player.transform.position.z);
        EnableLineRenderer(rendererStartPos, rendererEndPos);
        Jump();
        PlayAnimation();
        
    }

    public  void PlayAnimation()
    {
        
        animController.StartSwimming(true);

    }
}
