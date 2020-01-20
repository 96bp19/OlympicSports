using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTapZone : JumpTapZone
{
    public override void DoInputAction(float accuracy)
    {
        player.SetDefaultGravityMultiplier();
        player.ResetPlayerSpeed();
        base.DoInputAction(accuracy);
       
        
    }

    
}
