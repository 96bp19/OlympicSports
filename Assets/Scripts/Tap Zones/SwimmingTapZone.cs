using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingTapZone : JumpTapZone
{
    public override void DoInputAction(float accuracy)
    {
        
        base.DoInputAction(accuracy);
        PlayAnimation();
    }

    public override void PlayAnimation()
    {
        animController.StartSwimming(true);

    }
}
