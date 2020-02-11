using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingTapZone : JumpTapZone
{
    public override void DoInputAction(float accuracy)
    {
        
        base.DoInputAction(accuracy);
    }

    public override void PlayAnimation(AnimationController animController)
    {
        animController.StartSwimming(true);

    }
}
