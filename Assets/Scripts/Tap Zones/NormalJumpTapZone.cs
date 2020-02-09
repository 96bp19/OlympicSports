using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJumpTapZone : JumpTapZone
{
   
    public override void DoInputAction(float accuracy)
    {
        player.SetDefaultGravityMultiplier();
        base.DoInputAction(accuracy);

    }

}
