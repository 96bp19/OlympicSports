using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longJumpTapZone : JumpTapZone
{
    public override void DoInputAction(float accuracy)
    {
        player.setNewGravityMutiplier(1);
        base.DoInputAction(accuracy);
    }
}
