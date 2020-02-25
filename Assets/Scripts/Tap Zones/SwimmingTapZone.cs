using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingTapZone : JumpTapZone
{
   
    public override void OnScreenTap()
    {
        if (!inputListiningAllowed) return;
        base.OnScreenTap();
        Jump();
        PlayAnimation();
        
    }

    public override void PlayAnimation()
    {
        
        animController.StartSwimming(true);

    }
}
