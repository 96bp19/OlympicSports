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
        Jump();
        PlayAnimation();
        
    }

    public  void PlayAnimation()
    {
        
        animController.StartSwimming(true);

    }
}
