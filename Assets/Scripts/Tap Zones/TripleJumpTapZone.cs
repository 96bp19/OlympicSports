using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleJumpTapZone : JumpTapZone
{
    public override void PlayAnimation()
    {
        animController.TripleJump();
    }

    public override void DoInputAction(float accuracy)
    {
        PlayAnimation();
    }
}
