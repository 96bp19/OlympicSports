using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longJumpTapZone : JumpTapZone
{
    public override void DoInputAction()
    {
        player.setNewGravityMutiplier(1);
        base.DoInputAction();
    }
}
